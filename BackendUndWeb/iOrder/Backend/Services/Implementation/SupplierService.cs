using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository SupplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            SupplierRepository = supplierRepository;
        }

        public void Delete(object id)
        {
            SupplierRepository.Delete(SupplierRepository.GetById(id));
        }

        public IEnumerable<Supplier> GetAll()
        {
            return SupplierRepository.GetAll();
        }

        public Supplier GetById(object id)
        {
            return SupplierRepository.GetById(id);
        }

        public IEnumerable<Supplier> GetSuppliersForOwner(string username)
        {
            return SupplierRepository.GetSuppliersForOwner(username);
        }

        public void NotifySupplier(long id, string message)
        {
            var supplier = GetById(id);
            var email = supplier.Email;

            Console.WriteLine("Sending message to: " + supplier);
            Console.WriteLine("Message: " + message);
            // TODO send email to supplier

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("iorder.orderingservice", "Iorder123456");
            client.EnableSsl = true;
            client.Credentials = credentials;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("iorder.orderingservice@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Body = message + "\nThis is auto generated mail from iOrder Auto Ordering Server" + "\n" + "iorder Service\nOrdering Service\niOrder";
            mailMessage.Subject = "Product Order";
            client.Send(mailMessage);
        }

        public void Save(Supplier t)
        {
            SupplierRepository.Save(t);
        }

        public void Update(object id, Supplier t)
        {
            SupplierRepository.Update(id, t);
        }
    }
}
