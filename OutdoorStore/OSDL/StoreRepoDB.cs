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
        }

        public Model.Customer GetCustomerByName(string name)
        {
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
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
            return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList().FirstOrDefault(x => x.ID == num);
        }

        public Model.Product GetProductByShortName(string str)
        {
            return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList().FirstOrDefault(x => x.ShortName.Equals(str));
        }

        public List<Item> GetItems()
        {
            return _context.OrderItems.AsNoTracking().Select(x => _mapper.ParseItem(x)).ToList();
        }

        public List<Product> GetProductsByCategories(ProductCategory pcat)
        {
            switch(pcat)
            {
                case ProductCategory.Backpacks:
                    return _context.Products.AsNoTracking().Where(x => x.Category == 1).Select(x => _mapper.ParseProduct(x)).ToList();
                case ProductCategory.Camping:
                    return _context.Products.AsNoTracking().Where(x => x.Category == 2).Select(x => _mapper.ParseProduct(x)).ToList();
                case ProductCategory.Climbing:
                    return _context.Products.AsNoTracking().Where(x => x.Category == 3).Select(x => _mapper.ParseProduct(x)).ToList();
                case ProductCategory.Clothing:
                    return _context.Products.AsNoTracking().Where(x => x.Category == 4).Select(x => _mapper.ParseProduct(x)).ToList();
                case ProductCategory.Shoes:
                    return _context.Products.AsNoTracking().Where(x => x.Category == 5).Select(x => _mapper.ParseProduct(x)).ToList();
                default:
                    throw new NotImplementedException();
            }
        }

        public List<Inventory> GetInventories()
        {
            return _context.Inventories.AsNoTracking().Select(x => _mapper.ParseInventory(x)).ToList();
        }

        public Item AddItem(Item newItem)
        {
            _context.OrderItems.Add(_mapper.ParseItem(newItem));
            _context.SaveChanges();
            return newItem;
        }

        public Cart AddCart(Cart newCart)
        {
            try{
            _context.Carts.Add(_mapper.ParseCart(newCart));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return newCart;
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                Console.WriteLine("Are you really sure? Why don't you think about it for a second.");
                return newCart;
            }
        }

        public List<Cart> GetCarts()
        {
            return _context.Carts.AsNoTracking().Select(x => _mapper.ParseCart(x)).ToList();
        }

        public void EmptyCart()
        {
            _context.Carts.RemoveRange(_context.Carts.AsNoTracking().Select(x => x));
        }

        public void UpdateInventory(Inventory inv)
        {
            Entity.Inventory oldInv = _context.Inventories.Find(inv.ID);
            _context.Entry(oldInv).CurrentValues.SetValues(_mapper.ParseInventory(inv));

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}