using Backend.Notifications.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Notifications.Observer
{
    public class ObserverImpl : ObserverAbstract
    {
        public ObserverImpl(IObservable observable) : base(observable)
        {
        }

        public override void Notify(long establishmentId)
        {
            Console.WriteLine("Notifajan sam: " + establishmentId);
        }
    }
}
