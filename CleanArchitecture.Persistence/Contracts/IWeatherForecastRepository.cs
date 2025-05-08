namespace CleanArchitecture.Persistence.Contracts
{
    public interface IWeatherForecastRepository
    {
        Task<List<IWeatherForecastEntity>> GetAll();
    }
}
