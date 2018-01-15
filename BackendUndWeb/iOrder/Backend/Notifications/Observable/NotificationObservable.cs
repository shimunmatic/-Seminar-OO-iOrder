using Backend.Notifications.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Notifications.Observable
{
    public class NotificationObservable : IObservable
    {
        public void NotifyAll(long establishmentId) => NotificationManager.NotifyAll(establishmentId);

        public void Register(ObserverAbstract observer, long establishmentId) => NotificationManager.Register(observer, establishmentId);

        public void Unregister(ObserverAbstract observer, long establishmentId) => NotificationManager.Unregister(observer, establishmentId);
    }
}
