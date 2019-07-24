using System;
using System.Collections.Generic;

namespace TacitAssignment.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeliveryTypeCode { get; set; }
        public bool BrowseOnly { get; set; }
        public string Description { get; set; }
        public bool IsDailySpecial { get; set; }
        public List<DigitalAsset> DigitalAssets { get; set; }
        public List<MenuItemGroup> MenuItemGroups { get; set; }
    }

    public class DigitalAsset
    {
        public int Seq { get; set; }
        public string ImageLink { get; set; }
    }

    public class PairingGroups
    {
        public object FoodPairingId { get; set; }
        public object DrinkPairingId { get; set; }
        public object SidePairingId { get; set; }
    }

    public class DigitalAsset2
    {
        public int Seq { get; set; }
        public string ImageLink { get; set; }
    }

    public class Price
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Size { get; set; }
        public int Calories { get; set; }
        public List<object> Options { get; set; }
    }

    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDailySpecial { get; set; }
        public bool IsCustomizable { get; set; }
        public int MaxOrderItemQuantity { get; set; }
        public object PrepTimeInMinutes { get; set; }
        public bool SeqPrepIndicator { get; set; }
        public List<object> Badges { get; set; }
        public List<Price> Prices { get; set; }
        public List<object> DigitalAssets { get; set; }
        public List<object> Options { get; set; }
    }

    public class MenuItemGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Category { get; set; }
        public string Description { get; set; }
        public bool DontDisplayFlag { get; set; }
        public object PrepTimeInHours { get; set; }
        public PairingGroups PairingGroups { get; set; }
        public List<DigitalAsset2> DigitalAssets { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
