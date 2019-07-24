using System;
using System.Collections.Generic;

namespace TacitAssignment.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TimezoneId { get; set; }
        public string RestaurantTimezone { get; set; }
        public string IanaTimezoneId { get; set; }
        public string NewsText { get; set; }
        public string NewsTextFr { get; set; }
        public object NewsExpiryDatetime { get; set; }
        public Address Address { get; set; }
        public List<DigitalAsset> DigitalAssets { get; set; }
        public Preferences Preferences { get; set; }
        public List<AvailabilitySchedule> AvailabilitySchedules { get; set; }
        public List<RestaurantSetting> RestaurantSettings { get; set; }
        public List<object> DeliveryAddresses { get; set; }
        public List<object> ServiceCharges { get; set; }
        public GeoLocation GeoLocation { get; set; }
        public List<RestaurantMenu> RestaurantMenus { get; set; }
        public List<Availability> Availabilities { get; set; }
        public DateTime LastUpdatedDatetime { get; set; }
        public Localization Localization { get; set; }
        public List<object> PrepCoefficients { get; set; }
        public List<object> Holidays { get; set; }
        public List<object> DeliveryPoints { get; set; }
    }

    public class Address
    {
        public string PhoneNum { get; set; }
        public string PhoneExt { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public object AddressLine3 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string StateProvinceCode { get; set; }
    }


    public class Preferences
    {
        public bool BrowseOnly { get; set; }
        public bool Delivery { get; set; }
        public bool TakeOut { get; set; }
        public bool QuickOrder { get; set; }
        public bool CateringOrder { get; set; }
        public bool TimeSlotOrder { get; set; }
        public bool DisplayCalories { get; set; }
        public bool HasAdvancedOrders { get; set; }
        public object OrdersDelayedByTime { get; set; }
    }

    public class AvailabilitySchedule
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DayOfWeek { get; set; }
    }

    public class RestaurantSetting
    {
        public string SettingType { get; set; }
        public string OrderType { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }

    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class AvailabilitySchedule2
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DayOfWeek { get; set; }
    }

    public class RestaurantMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeliveryTypeCode { get; set; }
        public List<AvailabilitySchedule2> AvailabilitySchedules { get; set; }
        public bool IsDailySpecial { get; set; }
    }

    public class Availability
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<string> DaysOfWeek { get; set; }
    }

    public class En
    {
        public string Name { get; set; }
    }

    public class Fr
    {
        public string Name { get; set; }
    }

    public class Localization
    {
        public En En { get; set; }
        public Fr Fr { get; set; }
    }
}
