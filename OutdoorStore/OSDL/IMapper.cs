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

        Model.Item ParseItem(Entity.OrderItem orderItem);
        Entity.OrderItem ParseItem(Model.Item item);

        Model.Inventory ParseInventory(Entity.Inventory inv);
        Entity.Inventory ParseInventory(Model.Inventory inv);

        Model.Cart ParseCart(Entity.Cart cart);
        Entity.Cart ParseCart(Model.Cart cart);
    }
}