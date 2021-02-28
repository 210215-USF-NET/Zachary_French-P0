using System.Collections.Generic;
using Model = OSModels;
using Entity = OSDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using OSModels;

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
            _context.Customers.Add(_mapper.ParseCustomer(newCust));
            _context.SaveChanges();
            return newCust;
        }

        public List<Model.Customer> GetCustomers()
        {
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList();
            // //temp code:
            // throw new NotImplementedException();
        }

        public Model.Customer GetCustomerByName(string name)
        {
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.Name == name);
        }

        public Model.Order AddOrder(Model.Order newOrder)
        {
            _context.Orders.Add(_mapper.ParseOrder(newOrder));
            _context.SaveChanges();
            return newOrder;
        }

        public List<Model.Order> GetOrders()
        {
            return _context.Orders.AsNoTracking().Select(x => _mapper.ParseOrder(x)).ToList();
        }

        public List<Model.Location> GetLocations()
        {
            return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList();
        }

        public List<Model.Product> GetProducts()
        {
            return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList();
        }
        public Model.Product GetProductByID(int num)
        {
            return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList().FirstOrDefault(x => x.id == num);
        }

        public List<Item> GetItems()
        {
            return _context.OrderItems.AsNoTracking().Select(x => _mapper.ParseItem(x)).ToList();
        }

        //Commented out, may be unnecessary?
        // public List<Model.ProductCategory> GetProductCategories()
        // {
        //     return _context.ProductCategories.AsNoTracking().Select(x => _mapper.ParseCategory(x)).ToList();
        // }
    }
}