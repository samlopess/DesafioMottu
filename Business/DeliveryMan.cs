using DesafioMottu.Dao;
using DesafioMottu.Models;
using System.Text.RegularExpressions;

namespace DesafioMottu.Business
{
    public class DeliveryMan
    {
        DeliveryManDAO dao = new DeliveryManDAO();
        private static IConfigurationRoot configuration;
        static DeliveryMan()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        private readonly string storagePath = configuration["AppSettings:StoragePath"];

        #region Get

        #endregion Get

        #region Create

        public void CreateDeliveryMan(DeliveryManModel deliveryMan)
        {
            CreateImageLicense(deliveryMan);
            dao.CreateDeliveryMan(deliveryMan);
        }

        #endregion Create

        #region Update 

        public void UpdateDeliveryManImageLicense(DeliveryManModel deliveryMan)
        {
            DeleteImageLicense(deliveryMan.ImageLicence);
            CreateImageLicense(deliveryMan);
            dao.UpdateDeliveryManImageLicense(deliveryMan);

        }


        #endregion Update

        #region Delete

        #endregion Delete

        #region Private methods

        private void DeleteImageLicense(string imageLicensePath)
        {
             File.Delete(imageLicensePath);       
        }

        private void CreateImageLicense(DeliveryManModel deliveryMan)
        {
            string imageName = Guid.NewGuid().ToString() + ".jpg";
            string imagePath = Path.Combine(storagePath, imageName);
            byte[] imageBytes = Convert.FromBase64String(deliveryMan.ImageLicenceBase64);

            File.WriteAllBytesAsync(imagePath, imageBytes);

            deliveryMan.ImageLicence = imagePath;
        }

        #endregion Private methods
    }
}
