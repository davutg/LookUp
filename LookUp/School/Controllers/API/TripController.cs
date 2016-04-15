using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Diagnostics;
using School.DB;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Controllers.API
{
    [Route("api/[controller]")]
    public class TripController : Controller
    {
        private IWorldRepository _repo;

        public TripController(IWorldRepository repository)
        {
            _repo = repository;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_repo.GetAllTripsWithStops());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        public String val { get; set; }

        // POST api/values
        [HttpPost(template:"{val}")]
        public void Post(String val)
        {
            Debug.WriteLine("val:"+val.ToString());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
