using DesafioMottu.Business;
using DesafioMottu.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMottu.Controllers
{
    [ApiController]
    [Route("/MotorcycleController")]
    public class MotorcycleController : ControllerBase
    {

        #region Get

        [HttpGet("{licencePlate}", Name = "GetMotorcyleByLicencePlate")]
        public async Task<ActionResult<MotorcycleModel>> GetMotorcyleByLicencePlate(string licencePlate)
        {
            Motorcycle motorcycleBusines = new Motorcycle();
            return motorcycleBusines.GetMotorcycleByLicensePlate(licencePlate);
        }

        #endregion Get

        #region Post

        [HttpPost(Name = "CreateMotorcycle")]
        public async Task<IActionResult> CreateMotorcycle([FromBody] MotorcycleModel motorcycle)
        {
            Motorcycle motorcycleBusines = new Motorcycle();
            motorcycleBusines.CreateMotorcycle(motorcycle);

            return CreatedAtRoute(new { motorcycleId = motorcycle.Id }, motorcycle);
        }

        #endregion Post

        #region Put 

        [HttpPut(Name = "UpdateMotorcycle")]
        public async Task<IActionResult> UpdateMotorcycle([FromBody] MotorcycleModel motorcycle)
        {
            Motorcycle motorcycleBusines = new Motorcycle();
            motorcycleBusines.UpdateMotorcycle(motorcycle);

            return NoContent();
        }

        #endregion Put

        #region Delete

        [HttpDelete(Name = "DeleteMotorcycle")]
        public async Task<IActionResult> DeleteMotorcycleById([FromBody] int motorcycleId)
        {
            Motorcycle motorcycleBusines = new Motorcycle();
            motorcycleBusines.DeleteMotorcycle(motorcycleId);

            return NoContent();
        }

        #endregion Delete

    }
}
