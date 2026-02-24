namespace _12_DIExample_ServiceContracts
{
    public interface ICitiesService
    {
        Guid ServiceInstanceId { get; }
        public List<string> GetCities();

    }
}
