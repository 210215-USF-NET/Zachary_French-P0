using System.Collections.Generic;
using Model = OSModels;
using Entity = OSDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace OSDL
{
    public class StoreRepoDB : IStoreRepo
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;

        public StoreRepoDB(Entity.StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        public Model.Customer AddCustomer(Model.Customer newCust)
        {
            // _context.Customer.Add(_mapper.ParseCustomer(newCust));
            // _context.SaveChanges();
            return newCust;
        }

        public List<Model.Customer> GetCustomers()
        {
            // return _context.Customer.Select(x => _mapper.ParseCustomer(x)).ToList();
            //temp code:
            throw new NotImplementedException();
        }

        public Model.Customer GetCustomerByName(string name)
        {
            throw new NotImplementedException();
        }

        public Model.Order AddOrder(Model.Order order)
        {
            throw new NotImplementedException();
        }

        public List<Model.Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public List<Model.Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        public List<Model.Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Model.ProductCategory> GetProductCategories()
        {
            throw new NotImplementedException();
        }
    }
}