using Backend.Models.Business;
using Backend.Notifications.Observable;
using Backend.Notifications.Observer;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Observer
{
    public class OrdersHub : Hub
    {

        // Sends message to frontent that there was a change with orders.
        public void Send(string type, string message)
        {
            Clients.All.InvokeAsync("message", type, message);

        }

    }
}
