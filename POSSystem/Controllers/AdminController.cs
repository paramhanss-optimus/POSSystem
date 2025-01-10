//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using POSSystem.Domain.Entities;

//namespace POSSystem.Controllers
//{
//    public class AdminController : ControllerBase
//    {
//        [Authorize(Roles = "admin")]
//        [HttpGet]
//        [Route("api/admin/inventory")]
//        public IActionResult GetInventory()
//        {
//            // Admin logic to manage inventory
//            return Ok("Admin inventory access granted");
//        }

//        [HttpPost]
//        [Route("api/admin/users")]
//        public IActionResult CreateUser([FromBody] AdminEntity model)
//        {
//            // Admin logic to create a new user
//            return Ok("User created successfully");
//        }

//    }
//}


