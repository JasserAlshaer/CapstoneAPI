using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAPI.Helpers
{
    public static class TrackingHelper
    {
        public static double DegreesToRadians(double deg) => deg * (Math.PI / 180);

        public static double CalculateDistanceInKm(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Radius of Earth in kilometers
            var lat = ToRadians(lat2 - lat1);
            var lon = ToRadians(lon2 - lon1);
            var a = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(lon / 2) * Math.Sin(lon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double ToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }
        public static int GetEstimatedMinutes(double lat1, double lon1, double lat2, double lon2)
        {
            var distanceKm = CalculateDistanceInKm(lat1, lon1, lat2, lon2);
            var randomSpeed = new Random().Next(20, 41); // km/h
            var timeHours = distanceKm / randomSpeed;
            return (int)Math.Round(timeHours * 60);
        }

        
    }
}
