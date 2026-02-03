
using _03_RoutingCountries.Data;
using System.Net.WebSockets;

namespace _03_RoutingCountries.RouteConstraints
{
    public class CountryIdsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //if (!values.ContainsKey(routeKey)) return false;

            //int? routeId = Convert.ToInt32(values[routeKey]);

            //if (values.TryGetValue(routeKey, out var value) && int.TryParse(value?.ToString(), out int routeId))
            //{
            //    if (CountriesData.countries.ContainsKey(routeId))
            //    {
            //        return true;
            //    }
            //}

            // First Condition: Checks if RouteKey exists in the Dictionary
            // Retrieves its value into out var value
            // Second Condition: Ensures value retrieved from Dictionary is valid integer
            // If it's null or invalid, returns as fall
            if (values.TryGetValue(routeKey, out var value) && int.TryParse(value?.ToString(), out _))
            {
                return true;
            }

            return false;
        }
    }
}
