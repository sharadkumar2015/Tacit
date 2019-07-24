using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using TacitAssignment.Models;
using TacitAssignment.Repository;
using TacitAssignment.Utility;

namespace TacitAssignment.Controllers
{
    public class RestaurantController : ApiController
    {
        // GET api/values/5

        public async Task<string> Get(int RestaurantID,string prefFood, bool getFreshData=false)
        {
            ILogger logger = new Logger(); //i could have injected this from unit as well
            try
            {
                RestaurantRepository repo = new RestaurantRepository();
                if (getFreshData)
                    RedisCacheHelper.Remove(repo.GetCacheKey(RestaurantID, prefFood.ToUpper()));

                var dataFromCache = RedisCacheHelper.Get(repo.GetCacheKey(RestaurantID, prefFood.ToUpper()));

                if (dataFromCache != null)
                    return JsonConvert.SerializeObject(dataFromCache);

                string data = await repo.GetDataAsync(ConfigurationManager.AppSettings["RestaurantByIdURL"] + RestaurantID.ToString());

                List<RestaurantMenu> resMenu = new List<RestaurantMenu>();
                if (!string.IsNullOrEmpty(data))
                    resMenu = repo.GetRestaurantMenuIDs(data);

                return await repo.GetRestaurantMenuItems(resMenu, RestaurantID, prefFood.ToUpper());
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return "Error Occured";
            }
        }
    }
}
