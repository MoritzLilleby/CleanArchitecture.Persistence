using Microsoft.Extensions.Logging;
using Persistence.Behaviours.Greek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours.Norse.Observers
{
    internal class OdinRavens : IObservable<IWeatherGodVisitor>
    {
        private readonly HashSet<Subscription> subscriptions = new();

        public void Observe(IWeatherGodVisitor observer)
        {
            foreach (var sub in subscriptions)
            {
                sub.Observer.OnNext(observer);
            }

            Unsubscribe();
        }

        public IDisposable Subscribe(IObserver<IWeatherGodVisitor> observer)
        {
            var subscription = new Subscription(this, observer);
            subscriptions.Add(subscription);
            return subscription;
        }

        public void Unsubscribe()
        {
            foreach (var sub in subscriptions)
            {
                sub.Observer.OnCompleted();
            }
        }

        private sealed class Subscription(
            OdinRavens odinRavens,
            IObserver<IWeatherGodVisitor> observer
                ) : IDisposable
        {
            public IObserver<IWeatherGodVisitor> Observer = observer;

            public void Dispose()
            {
                odinRavens.subscriptions.Remove(this);
            }
        }
    }
}
