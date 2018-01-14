using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class WarehouseService : IWarehouseService
    {

        private IWarehouseRepository WarehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            WarehouseRepository = warehouseRepository;
        }

        public void Delete(object id)
        {
            WarehouseRepository.Delete(WarehouseRepository.GetById(id));
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return WarehouseRepository.GetAll();
        }

        public Warehouse GetById(object id)
        {
            return WarehouseRepository.GetById(id);
        }

        public int GetQuantityForProductInWarehouse(long productId, long warehouseId)
        {
            return WarehouseRepository.GetQuantityForProductInWarehouse(productId, warehouseId);
        }

        public IEnumerable<Warehouse> GetWarehousesForOwner(string username)
        {
            return WarehouseRepository.GetWearhousesForOwner(username);
        }

        public void Save(Warehouse t)
        {
            WarehouseRepository.Save(t);
        }

        public void Update(object id, Warehouse t)
        {
            WarehouseRepository.Update(id, t);
        }
    }
}
