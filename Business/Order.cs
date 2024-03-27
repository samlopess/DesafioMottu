using DesafioMottu.Dao;
using DesafioMottu.Models;

namespace DesafioMottu.Business
{
    public class Order
    {
        OrderDAO dao = new OrderDAO();

        #region Create

        public void CreateOrder(OrderModel order)
            => dao.CreateOrder(order);

        #endregion Create
    }
}
