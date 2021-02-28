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
            throw new NotImplementedException();
        }
        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        public Model.Order ParseOrder(Entity.Order order)
        {
            throw new NotImplementedException();
        }
        public Entity.Order ParseOrder(Model.Order order)
        {
            throw new NotImplementedException();
        }

        public Model.Location ParseLocation(Entity.Location location)
        {
            throw new NotImplementedException();
        }
        public Entity.Location ParseLocation(Model.Location location)
        {
            throw new NotImplementedException();
        }

        public Model.Product ParseProduct(Entity.Product product)
        {
            return new Model.Product {
                Name = product.Name,
                PID = product.Shortname,
                Price = product.Price,
                Category = (Model.ProductCategory) product.Category,
                Description = product.Description
            };
        }
        public Entity.Product ParseProduct(Model.Product product)
        {
            return new Entity.Product{
                Name = product.Name,
                Shortname = product.PID,
                Price = product.Price,
                Category = (int) product.Category,
                Description = product.Description
            };
        }

        // Model.ProductCategory ParseProduct(Entity.ProductCategory category)
        // {
        //     return new ProductCategory
        // }
        // Model.ProductCategory ParseProduct(Entity.ProductCategory category)
        // {
        //     throw new NotImplementedException();
        // }
    }
}