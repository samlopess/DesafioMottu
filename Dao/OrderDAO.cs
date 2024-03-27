using DesafioMottu.Data;
using DesafioMottu.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioMottu.Dao
{
    public class OrderDAO
    {
        #region Create

        public void CreateOrder(OrderModel order)
        {
            using(var dbContext = new ChallengeDbContext())
            {
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
            }
        }


        #endregion Create
    }
}
