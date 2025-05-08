using CleanArchitecture.Persistence.Behaviours.Greek;
using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Creational
{
    internal class GreekWeatherGodVisitorFactory : ICreateWeatherGodVisitor
    {
        private static readonly IWeatherGodVisitor[] greekGods = { new Boreas(), new Eurus(), new Notus(), new Zephyrus(), new Zeus() };
        private static readonly Random random = new();

        public IWeatherGodVisitor CreateRandomWeatherGodVisitor()
        {
            var god = greekGods[random.Next(greekGods.Length)];
            return god;
        }
    }
}
