using DesafioMottu.Dao;
using DesafioMottu.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace DesafioMottu.Business
{
    public class Rental
    {
        RentalDAO dao = new RentalDAO();

        #region Get

        public double GetRentalValue(RentalModel rental)
            =>CalculateRentalValue(rental);
        

        #endregion Get

        #region Create

        public string CreateRental(RentalModel rental)
        {
            DeliveryManDAO deliveryManDAO = new DeliveryManDAO();
            MotorcycleDAO motorcycleDAO = new MotorcycleDAO();
            bool typeLicenceA = deliveryManDAO.GetTypeLicenceDeliveryMan(rental.DeliveryManId);
            bool hasMotorcycleAvailable = motorcycleDAO.HasMotorcycleAvailable();
             
            if (!typeLicenceA)
            {
                return "Only DeliveryMans with type licence A can rent a motorcycle";
            }
            
            if (!hasMotorcycleAvailable)
            {
                return "We don't have motorcycles available";
            }

            CalculateRentalValue(rental);
            rental.MotorcycleId = motorcycleDAO.GetMotorcycleForRental();
            dao.CreateRental(rental);
            motorcycleDAO.UpdateMotorcycleAvailable(rental.MotorcycleId, 1);

            return "Rental completed successfully";
        }

        #endregion Create

        #region private methods

        private double CalculateRentalValue(RentalModel rental) 
        {
            TimeSpan differenceDays = DateTime.Now - rental.ExpectedEndDate;

            if (rental.Plans == 0)
            {
                rental.Value = 7 * 30;

                if (differenceDays.TotalDays > 7)
                    CalculateRentalValueWithExtras(rental, differenceDays, 0.20);               
            }

            if (rental.Plans == 1)
            {
                rental.Value = 15 * 28;

                if (differenceDays.TotalDays > 15)
                    CalculateRentalValueWithExtras(rental, differenceDays, 0.40);
            }

            if(rental.Plans == 2)
            {
                rental.Value = 30 * 22;

                if (differenceDays.TotalDays > 30)
                    CalculateRentalValueWithExtras(rental, differenceDays, 0.60);
            }     

            return rental.Value;
        }

        private double CalculateFine(double interest, double valueAdditionalDays)
            => valueAdditionalDays * interest;

        private double CalculateValueAdditionalDays(double dailyRate, double numberDays)
            => dailyRate * numberDays;

        private void CalculateRentalValueWithExtras(RentalModel rental, TimeSpan differenceDays, double interest)
        {
            double valueAdditionalDays;
            double fine;
            valueAdditionalDays = CalculateValueAdditionalDays(50, differenceDays.TotalDays);
            fine = CalculateFine(interest, valueAdditionalDays);

            rental.Value = rental.Value + fine + valueAdditionalDays;
        }
    
        #endregion private methods
    }
}

