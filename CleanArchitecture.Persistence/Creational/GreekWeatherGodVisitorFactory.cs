using Persistence.Behaviours.Greek;

namespace Persistence.Creational
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
