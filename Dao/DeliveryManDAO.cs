using DesafioMottu.Business;
using DesafioMottu.Data;
using DesafioMottu.Models;

namespace DesafioMottu.Dao
{
    public class DeliveryManDAO
    {
        #region Get

        public bool GetTypeLicenceDeliveryMan(int deliveryManId)
        {

            using (var dbContext = new ChallengeDbContext())
            {
                var deliveryMans = dbContext.DeliveryMans.Where(r => r.Id == deliveryManId && r.TypeLicence == "A").ToList();

                if(deliveryMans.Count > 0)
                {
                    return true;
                }              
            }

            return false;

        }

        #endregion Get

        #region Create

        public void CreateDeliveryMan(DeliveryManModel deliveryMan)
        {
            using (var dbContext = new ChallengeDbContext())
            {
                dbContext.DeliveryMans.Add(deliveryMan);
                dbContext.SaveChanges();
            }
        }

        #endregion Create

        #region Update

        public void UpdateDeliveryManImageLicense(DeliveryManModel deliveryMan)
        {
            using (var dbContext = new ChallengeDbContext())
            {
                var existingDeliveryMan = dbContext.DeliveryMans.Find(deliveryMan.Id);

                if(existingDeliveryMan != null)
                {
                    existingDeliveryMan.ImageLicence = deliveryMan.ImageLicence;
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion Update
    }
}
