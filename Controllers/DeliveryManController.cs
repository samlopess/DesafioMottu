using DesafioMottu.Business;
using DesafioMottu.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMottu.Controllers
{
    [ApiController]
    [Route("/DeliveryManController")]
    public class DeliveryManController : ControllerBase
    {
        #region Post
        [HttpPost(Name = "CreateDeliveryMan")]
        public async Task<IActionResult> CreateDeliveryMan([FromBody] DeliveryManModel deliveryMan)
        {
            DeliveryMan deliveryManBusines = new DeliveryMan();
            deliveryManBusines.CreateDeliveryMan(deliveryMan);

            return CreatedAtRoute(new { deliveryMan = deliveryMan.Id }, deliveryMan);
        }
        #endregion Post

        #region Put 
        [HttpPut(Name = "UpdateDeliveryManImageLicense")]
        public async Task<IActionResult> UpdateDeliveryManImageLicense([FromBody] DeliveryManModel deliveryMan)
        {
            DeliveryMan deliveryManBusines = new DeliveryMan();
            deliveryManBusines.UpdateDeliveryManImageLicense(deliveryMan);

            return NoContent();
        }

        #endregion Put
    }
}
