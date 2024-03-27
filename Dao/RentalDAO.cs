using DesafioMottu.Business;
using DesafioMottu.Data;
using DesafioMottu.Models;

namespace DesafioMottu.Dao
{
    public class RentalDAO
    {
        #region Get

        public bool VerifyIfMotorcycleHasRental(int rentalId)
        {
            using (var dbContext = new ChallengeDbContext())
            {
                var rentals = dbContext.Rentals.Where(r => r.MotorcycleId == rentalId).ToList();

                if (rentals.Any())
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Create

        public void CreateRental(RentalModel rental)
        {
            using(var dbContext = new ChallengeDbContext())
            {
                dbContext.Rentals.Add(rental);
                dbContext.SaveChanges();
            }
        }

        #endregion
    }
}
