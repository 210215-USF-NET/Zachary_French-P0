using Model = OSModels;
using Entity = OSDL.Entities;

namespace OSDL
{
    /// <summary>
    /// To parse entities from DB to Models used in BL and vice versa.
    /// </summary>
    public interface IMapper
    {
        Model.Customer ParseCustomer(Entity.Customer customer);
        Entity.Customer ParseCustomer(Model.Customer customer);

        Model.Order ParseOrder(Entity.Order order);
        Entity.Order ParseOrder(Model.Order order);

        Model.Location ParseLocation(Entity.Location location);
        Entity.Location ParseLocation(Model.Location location);

        Model.Product ParseProduct(Entity.Product product);
        Entity.Product ParseProduct(Model.Product product);

    }
}