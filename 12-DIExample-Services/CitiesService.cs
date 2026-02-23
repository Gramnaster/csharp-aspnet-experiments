namespace _12_DIExample_Services
{
    public class CitiesService
    {
        // Anything logic not related to the Controller or DB layer
        private List<string> _cities = [];

        public CitiesService()
        {
            _cities = [
                "London", 
                "Paris", 
                "New York", 
                "Tokyo", 
                "Rome"
            ];
        }

        public List<string> GetCities()
        {
            return _cities;
        }
    }
}
