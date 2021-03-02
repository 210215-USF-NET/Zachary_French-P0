using Model = OSModels;
using Entity = OSDL.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace OSDL
{
    public class StoreMapper : IMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer {
                Name = customer.Name,
                Address = customer.Address,
                ID = customer.Id,
                Phone = customer.Phone
            };
        }
        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            return new Entity.Customer {
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone
            };
        }

        public Model.Order ParseOrder(Entity.Order order)
        {
            return new Model.Order {
                CustomerID = (int) order.CustId,
                OrderID = (int) order.Id,
                LocationID = (int) order.LocId,
                Date = order.Date
            };
        }
        public Entity.Order ParseOrder(Model.Order order)
        {
            return new Entity.Order {
                CustId = order.CustomerID,
                Id = order.OrderID,
                LocId = order.LocationID,
                Date = order.Date
            };
        }

        public Model.Location ParseLocation(Entity.Location location)
        {
            return new Model.Location {
                ID = location.Id,
                Name = location.Name,
                Address = location.Address
            };
        }
        public Entity.Location ParseLocation(Model.Location location)
        {
            return new Entity.Location {
                Id = location.ID,
                Name = location.Name,
                Address = location.Address
            };
        }

        public Model.Product ParseProduct(Entity.Product product)
        {
            return new Model.Product {
                Name = product.Name,
                ID = product.Id,
                ShortName = product.Shortname,
                Price = product.Price,
                Category = (Model.ProductCategory) product.Category,
                Description = product.Description
            };
        }
        public Entity.Product ParseProduct(Model.Product product)
        {
            return new Entity.Product{
                Name = product.Name,
                Id = product.ID,
                Shortname = product.ShortName,
                Price = product.Price,
                Category = (int) product.Category,
                Description = product.Description
            };
        }
        public Model.Item ParseItem(Entity.OrderItem orderItem)
        {
            return new Model.Item {
                ID = orderItem.Id,
                OrderID = (int) orderItem.OrderId,
                ProductID = (int) orderItem.ProductId,
                Quantity = orderItem.Quantity
            };
        }

        public Entity.OrderItem ParseItem(Model.Item item)
        {
            return new Entity.OrderItem {
                Id = item.ID,
                OrderId = item.OrderID,
                ProductId = item.ProductID,
                Quantity = item.Quantity
            };
        }

        public Model.Inventory ParseInventory(Entity.Inventory inv)
        {
            return new Model.Inventory {
                ID = inv.Id,
                Quantity = inv.Quantity,
                LocationID = (int) inv.LocationId,
                ProductID = (int) inv.ProductId
            };
        }

        public Entity.Inventory ParseInventory(Model.Inventory inv)
        {
            return new Entity.Inventory {
                Id = inv.ID,
                Quantity = inv.Quantity,
                LocationId = (int) inv.LocationID,
                ProductId = (int) inv.ProductID
            };
        }

        public Model.Cart ParseCart(Entity.Cart cart)
        {
            return new Model.Cart {
                ID = cart.Id,
                CustID = cart.CustId,
                LocID = cart.LocId,
                ProductID = cart.ProductId,
                Quantity = cart.Quantity
            };
        }
        public Entity.Cart ParseCart(Model.Cart cart)
        {
            return new Entity.Cart {
                Id = cart.ID,
                CustId = cart.CustID,
                LocId = cart.LocID,
                ProductId = cart.ProductID,
                Quantity = cart.Quantity
            };
        }
    }
}