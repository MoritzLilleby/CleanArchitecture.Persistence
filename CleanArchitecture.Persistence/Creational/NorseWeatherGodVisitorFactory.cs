using Persistence.Behaviours.Greek;
using Persistence.Behaviours.Norse;

namespace Persistence.Creational
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
