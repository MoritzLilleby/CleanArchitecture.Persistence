using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Creational
{
    internal interface ICreateWeatherGodVisitor
    {
        public IWeatherGodVisitor CreateRandomWeatherGodVisitor();
    }
}
