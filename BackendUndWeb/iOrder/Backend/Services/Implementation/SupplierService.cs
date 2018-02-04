using Backend.CommunicationServices;
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
        private ICommunicationService CommunicationService;

        public SupplierService(ISupplierRepository supplierRepository, ICommunicationService communicationService)
        {
            SupplierRepository = supplierRepository;
            CommunicationService = communicationService;
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
            if (null == supplier || supplier.Email == null)
                return;
            var email = supplier.Email;

            var subject = "Prodcut Order";
            message = message + "\nThis is auto generated mail from iOrder Auto Ordering Server" + "\n" + "iorder Service\nOrdering Service\niOrder";


            CommunicationService.SendMessage(email, message, subject);

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
