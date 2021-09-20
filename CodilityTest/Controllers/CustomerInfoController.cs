using CodilityTest.Data;
using CodilityTest.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodilityTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly IRepository _repo;
        public CustomerInfoController(IRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<CustomerInfoController>
        [HttpGet]
        public ActionResult<List<CustomerInfo>> GetCustomers()
        {
            return new JsonResult(_repo.GetAllCustomers());
        }

        // GET api/<CustomerInfoController>/5
        [HttpGet("{firstName}/{surName}")]
        public ActionResult<CustomerInfo> Get(string firstName,string surName)
        {
            return new JsonResult( _repo.GetCustomerByName(firstName, surName)); 
        }

        // POST api/<CustomerInfoController>
        [HttpPost]
        public ActionResult<CustomerInfo> Post()
        {
            return new JsonResult(_repo.CreateNewCustomer());
        }
    }
}
