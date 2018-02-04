using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.CommunicationServices
{
    public interface ICommunicationService
    {
        void SendMessage(string Destination, string Message, string Subject);
    }
}
