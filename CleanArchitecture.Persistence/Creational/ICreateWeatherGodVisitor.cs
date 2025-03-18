using Persistence.Behaviours.Greek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Creational
{
    internal interface ICreateWeatherGodVisitor
    {
        public IWeatherGodVisitor CreateRandomWeatherGodVisitor();
    }
}
