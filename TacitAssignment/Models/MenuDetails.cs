using System;
using System.ComponentModel.DataAnnotations;

namespace TacitAssignment.Models
{
    [Serializable]
    public class MenuDetails
    {
        public int RestaurantID { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuName { get; set; }
        public string DeliveryTypeCode { get; set; }
    }
}