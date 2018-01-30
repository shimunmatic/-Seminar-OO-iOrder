using Backend.Notifications.Observable;
using Backend.Notifications.Observer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Observer
{
    public class OrdersObserver : ObserverAbstract
    {
        OrdersHub hub;

        public OrdersObserver(IObservable observable, OrdersHub hub) : base(observable)
        {
            // Inject SignalR orders hub.
            this.hub = hub;
            Debug.WriteLine("Observer init");
        }

        public override void Notify(long establishmentId)
        {
            Debug.WriteLine("Observer message received");
            hub.Send("FROM", establishmentId.ToString());
        }
    }
}
