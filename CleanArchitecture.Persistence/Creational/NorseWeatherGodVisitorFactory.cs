using CleanArchitecture.Persistence.Behaviours.Norse;
using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Creational
{
    internal class NorseWeatherGodVisitorFactory : ICreateWeatherGodVisitor
    {
        private static readonly IWeatherGodVisitor[] norseGods = [new Thor(), new Odin()];
        private static readonly Random random = new();

        public IWeatherGodVisitor CreateRandomWeatherGodVisitor()
        {
            var god = norseGods[random.Next(norseGods.Length)];
            return god;
        }
    }
}
