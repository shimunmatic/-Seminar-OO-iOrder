using Backend.Notifications.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Notifications.Observable
{
    public interface IObservable
    {
        void Register(ObserverAbstract observer, long establishmnetId);
        void Unregister(ObserverAbstract observer, long establishmnetId);
        void NotifyAll(long establishmentId);
    }
}
