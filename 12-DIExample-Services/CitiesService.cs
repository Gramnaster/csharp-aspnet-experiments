using _12_DIExample_ServiceContracts;

namespace _12_DIExample_Services
{
    public class CitiesService : ICitiesService, IDisposable
    {
        // Anything logic not related to the Controller or DB layer
        private readonly List<string> _cities = [];
        private readonly Guid _serviceInstanceId;
        public Guid ServiceInstanceId 
        {
            get
            {
                return _serviceInstanceId;
            }
        }

        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities = [
                "London", 
                "Paris", 
                "New York", 
                "Tokyo", 
                "Rome"
            ];
            // Add logic to open the DB Connection
        }

        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            // Add logic to close the DB Connection
            // At the end of the request, it calls the Dispose to close all services
        }
    }
}
