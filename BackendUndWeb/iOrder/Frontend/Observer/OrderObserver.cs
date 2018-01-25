using Backend.Models.Business;
using Backend.Notifications.Observable;
using Backend.Notifications.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Observer
{
    public class OrderObserver : ObserverAbstract
    {
        public OrderObserver(IObservable observable) : base(observable)
        {
            
        }

        public override void Notify(long establishmentId)
        {
            Console.WriteLine("Notifajan sam: " + establishmentId);
        }
    }
}
