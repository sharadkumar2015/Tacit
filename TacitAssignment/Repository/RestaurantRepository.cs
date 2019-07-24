using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TacitAssignment.Interfaces;
using TacitAssignment.Models;
using TacitAssignment.Utility;

namespace TacitAssignment.Repository
{
    public class RestaurantRepository : HttpClientBase, IRepository
    {
        public async Task<string> GetDataAsync(string url)
        {
            string data = string.Empty;
            HttpResponseMessage response = await GetHttpClient().GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
            }
            return data;
        }

        public List<RestaurantMenu> GetRestaurantMenuIDs(string data)
        {
            Restaurant _restaurant = JsonConvert.DeserializeObject<Restaurant>(data);
            var menus = _restaurant.RestaurantMenus.Select(
                    x => new RestaurantMenu { Id = x.Id, Name = x.Name, DeliveryTypeCode = x.DeliveryTypeCode, }
                ).ToList();
            return menus;
        }

        public async Task<string> GetRestaurantMenuItems(List<RestaurantMenu> menus,int _restaurantID,string pref="BURGER")
        {
            string data = string.Empty;
            List<List<MenuDetails>> _menuDetails = new List<List<MenuDetails>>();

            foreach (var menu in menus)
            {
                data = await GetDataAsync(ConfigurationManager.AppSettings["MenuByIdURL"] + menu.Id);
                Menu _menu = JsonConvert.DeserializeObject<Menu>(data);

                var menuItemsWithPref = _menu.MenuItemGroups.SelectMany(
                        x => x.MenuItems
                            .Where(y => y.Name.ToUpper().Contains(pref.ToUpper()))
                            .Select(y => new MenuDetails
                                                {
                                                    RestaurantID = _restaurantID,
                                                    MenuItemId = y.Id,
                                                    MenuItemName = y.Name,
                                                    MenuName = menu.Name,
                                                    DeliveryTypeCode = menu.DeliveryTypeCode
                                                })
                    ).ToList();
                _menuDetails.Add((List<MenuDetails>)menuItemsWithPref);
            }

            //Creating the Cache Key as RestaurantID+PREF
            //For the assignment i am not converting this value to fixed lennth hash key
            string cacheKey = string.Format("{0}{1}", _restaurantID.ToString(),pref.ToUpper());
            RedisCacheHelper.Set(GetCacheKey(_restaurantID,pref), _menuDetails);
            return JsonConvert.SerializeObject(_menuDetails); ;
        }

        public string GetCacheKey(int _restaurantID, string pref = "BURGER")
        {
            return string.Format("{0}{1}", _restaurantID.ToString(), pref.ToUpper());
        }
    }
}