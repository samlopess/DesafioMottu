using DesafioMottu.Business;
using DesafioMottu.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMottu.Controllers
{
    [ApiController]
    [Route("/OrderController")]
    public class OrderController : ControllerBase
    {
        #region Create

        [HttpPost(Name = "CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel order)
        {
            Order orderBusiness = new Order();
            

            return CreatedAtRoute(new { order = order.Id }, order);
        }

        #endregion Create
    }
}
