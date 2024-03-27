using DesafioMottu.Business;
using DesafioMottu.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMottu.Controllers
{
    [ApiController]
    [Route("/RentalController")] 
    public class RentalController : ControllerBase
    {

        #region Get
        [HttpPost(Name = "GetRentalValue")]
        public async Task<ActionResult<double>> GetRentalValue([FromBody] RentalModel rental)
        {
            Rental rentalBusiness = new Rental();
            return rentalBusiness.GetRentalValue(rental);
        }

        #endregion Get

        #region Post

        [HttpPost(Name = "CreateRental")]
        public async Task<IActionResult> CreateRental([FromBody] RentalModel rental)
        {
            Rental rentalBusiness = new Rental();
            var message = rentalBusiness.CreateRental(rental);

            if (message != "Rental completed successfully")
                return CreatedAtRoute(message, rental);

            return CreatedAtRoute(new { rental = rental.Id }, rental);
        }

        #endregion Post

    }
}
