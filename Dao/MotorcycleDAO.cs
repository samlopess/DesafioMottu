using DesafioMottu.Business;    
using DesafioMottu.Data;
using DesafioMottu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace DesafioMottu.Dao
{
    public class MotorcycleDAO
    {
        #region Get

        public MotorcycleModel GetMotorcycleByLicensePlate(string licensePlate)
        {
            using(var dbContext = new ChallengeDbContext())
            {
                var motorcycle = dbContext.Motorcycles.FirstOrDefault(m => m.LicencePlate == licensePlate);
                return motorcycle;
            }
        }

        public int GetMotorcycleForRental()
        {
            using (var dbContext = new ChallengeDbContext())
            {
                var motorcycle = dbContext.Motorcycles.First(m => m.MotorcycleAvailable == 0);
                return motorcycle.Id;
            }
        }

        public bool HasMotorcycleAvailable() 
        { 
            using(var dbContext = new ChallengeDbContext())
            {
                var motorcycle = dbContext.Motorcycles.Where(m => m.MotorcycleAvailable == 0);

                if(motorcycle.Count() > 0)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Create
        public void CreateMotorcycle(MotorcycleModel motorcycle)
        {
            using (var dbContext = new ChallengeDbContext())
            {
                dbContext.Motorcycles.Add(motorcycle);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Update 
        public void UpdateMotorcycle(MotorcycleModel motorcycle)
        {
            using (var dbContext = new ChallengeDbContext())
            {
                var existingMotorcycle = dbContext.Motorcycles.Find(motorcycle.Id);

                if(existingMotorcycle != null)
                {
                    existingMotorcycle.LicencePlate = motorcycle.LicencePlate;
                    existingMotorcycle.Model = motorcycle.Model;
                    existingMotorcycle.Year = motorcycle.Year;
                    existingMotorcycle.MotorcycleAvailable = motorcycle.MotorcycleAvailable;

                    dbContext.SaveChanges();
                }
            }
        }

        public void UpdateMotorcycleAvailable(int motorcycleId, int motorcycleAvailable)
        {
            using(var dbContext = new ChallengeDbContext())
            {
                var motorcycle = dbContext.Motorcycles.Find(motorcycleId);

                if(motorcycle != null)
                {
                    motorcycle.MotorcycleAvailable = motorcycleAvailable;
                    dbContext.SaveChanges();
                }
            }

        }
        #endregion Update

        #region Delete

        public void DeleteMotorcycle(int motorcycleId)
        {
            using(var dbContext = new ChallengeDbContext())
            {
                var motorcycle = dbContext.Motorcycles.FirstOrDefault(m => m.Id == motorcycleId);

                if (motorcycle != null)
                {
                    dbContext.Motorcycles.Remove(motorcycle);
                    dbContext.SaveChanges();
                }
            }
        }

        #endregion Delete
    }
}
