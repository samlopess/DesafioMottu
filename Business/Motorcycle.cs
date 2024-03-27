using DesafioMottu.Dao;
using DesafioMottu.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMottu.Business
{
    public class Motorcycle
    {
        MotorcycleDAO dao = new MotorcycleDAO();

        #region Get
        public MotorcycleModel GetMotorcycleByLicensePlate(string licensePlate)
          => dao.GetMotorcycleByLicensePlate(licensePlate);      
        #endregion Get

        #region Create
        public void CreateMotorcycle(MotorcycleModel motorcycle)
           => dao.CreateMotorcycle(motorcycle);
        #endregion Create

        #region Update 
        public void UpdateMotorcycle(MotorcycleModel motorcycle)
            => dao.UpdateMotorcycle(motorcycle);
        #endregion Update

        #region Delete
        public string DeleteMotorcycle(int motorcycleId)
        {
            RentalDAO rentalDao = new RentalDAO();
            var motorcyleHasRental = rentalDao.VerifyIfMotorcycleHasRental(motorcycleId);
            if (motorcyleHasRental)
            {
                return "It is not permitted to exclude motorcycles with rental registration";
            }

            dao.DeleteMotorcycle(motorcycleId);
            return "Successfully deleted";
        }
        #endregion Delete
    }
}
