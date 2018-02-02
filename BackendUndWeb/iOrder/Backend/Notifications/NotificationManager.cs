using Backend.Notifications.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Notifications
{
    public static class NotificationManager
    {
        private static Dictionary<long, HashSet<ObserverAbstract>> Observers = new Dictionary<long, HashSet<ObserverAbstract>>();

        public static void NotifyAll(long establishmentId)
        {
            if (Observers.ContainsKey(establishmentId))
            {
                Observers[0].First().Notify(establishmentId);
                //foreach (var o in Observers[establishmentId])
                //{
                //    o.Notify(establishmentId);
                //}
            }
        }

        public static void Register(ObserverAbstract observer, long establishmnetId)
        {
            if (!Observers.ContainsKey(establishmnetId))
            {
                var list = new HashSet<ObserverAbstract>();
                list.Add(observer);
                Observers.Add(establishmnetId, list);
            }
            else
            {
                Observers[establishmnetId].Add(observer);
            }
        }

        public static void Unregister(ObserverAbstract observer, long establishmnetId)
        {
            if (!Observers.ContainsKey(establishmnetId))
                Observers[establishmnetId].Remove(observer);
        }
    }
}
