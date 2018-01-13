using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly int DEFAULT_MINIMUM_STORRAGE = 5;
        private readonly int DEFAULT_BUYING_QUANTITY = 20;
        private IOrderRepository OrderRepository;
        private IWarehouseService WarehouseService;
        private IEstablishmentService EstablishmentService;
        private IProductService ProductService;
        private ISupplierService SupplierService;

        public OrderService(IOrderRepository orderRepository, IWarehouseService warehouseService, IEstablishmentService establishmentService, IProductService productService, ISupplierService supplierService)
        {
            OrderRepository = orderRepository;
            WarehouseService = warehouseService;
            EstablishmentService = establishmentService;
            ProductService = productService;
            SupplierService = supplierService;
        }

        public void Delete(object id)
        {
            OrderRepository.Delete(OrderRepository.GetById(id));
        }

        public IEnumerable<Order> GetAll()
        {
            return OrderRepository.GetAll();
        }

        public Order GetById(object id)
        {
            return OrderRepository.GetById(id);
        }

        public IEnumerable<Order> GetCustomerHistoryForEstablishmentId(string username, long id)
        {
            var allOrders = OrderRepository.GetOrdersForCustomer(username);
            return allOrders.Where(o => o.EstablishmentId == id).ToList();
        }

        public IEnumerable<Order> GetHistoryEstablishmentId(long id)
        {
            return OrderRepository.GetOrdersForEstablishment(id);
        }

        public void Save(Order order)
        {
            var warehouseId = EstablishmentService.GetById(order.EstablishmentId).WarehouseId;

            foreach (var product in order.OrderedProducts)
            {
                ProductService.ReduceProductQuantityFromWarehouse(product.Product.Id, warehouseId, product.Quantity);
                var quantity = WarehouseService.GetQuantityForProductInWarehouse(product.Product.Id, warehouseId);
                if (quantity < DEFAULT_MINIMUM_STORRAGE)
                {
                    var p = ProductService.GetById(product.Product.Id);
                    SupplierService.NotifySupplier(p.SupplierId, GetMessage(p));
                    // todo send email to supplier
                }
            }
            OrderRepository.Save(order);
        }

        private string GetMessage(Product p)
        {

            return "Order for: " + p.ToString() + "\n" + "Quantity: " + DEFAULT_BUYING_QUANTITY;


        }

        public void SetPaid(long id)
        {
            var order = OrderRepository.GetById(id);
            order.Paid = true;
            Update(id, order);
        }

        public void Update(object id, Order t)
        {
            OrderRepository.Update(id, t);
        }
    }
}
