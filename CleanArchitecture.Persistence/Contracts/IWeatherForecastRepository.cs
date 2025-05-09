namespace CleanArchitecture.Persistence.Contracts
{
    public interface IWeatherForecastRepository
    {
        Task<List<IWeatherForecastEntity>> GetAll();

        Task CreateGreekWeather();
        Task CreateNorseWeather();

        public Task InsertOrUpdateList(IEnumerable<IWeatherForecastEntity> myList);
    }
}
