using Backend.Notifications.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Notifications.Observer
{
    public abstract class ObserverAbstract
    {
        private IObservable Observable;
        public ObserverAbstract(IObservable observable) => Observable = observable;

        protected void Register(long establishmentId) => Observable.Register(this, establishmentId);
        protected void Unregister(long establishmentId) => Observable.Unregister(this, establishmentId);
        public abstract void Notify(long establishmentId);
    }
}
