using AccountingSystemAPI.Interfaces;
using AccountingSystemAPI.Models;
using AccountingSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemFace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderService;
        public OrderController(IOrder orderService)
        {
                _orderService = orderService;
        }
        [HttpPost]
        [Route("AddNewOrder")]
        public async Task<IActionResult> AddNewOrder([FromBody] Order order)
        {
            
                var data = await _orderService.AddNewOrder(order);
                return Ok(data);
            
        }
        [HttpGet]
        [Route("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            var data = await _orderService.GetAllOrder();
            return Ok(data);
        }
        [HttpGet]
        [Route("GetOrderById/{orderId}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var data = await _orderService.GetOrderById(id);
            return Ok(data);    
        }
        [HttpPut]
        [Route("EditOrder/{orderId}")]
        public async Task<IActionResult> EditOrder(int id, [FromBody]Order order)
        {
            var data = await _orderService.EditOrder(id,order);
            return Ok(data);
        }
        [HttpDelete]
        [Route("DeleteOrder/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var data =  _orderService.DeleteOrder(id);
            return Ok(data);
        }

    }
}
