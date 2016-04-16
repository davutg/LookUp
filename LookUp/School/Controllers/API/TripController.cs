using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Diagnostics;
using School.DB;
using School.Model;
using School.ViewModel;
using System.Net;
using AutoMapper;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Controllers.API
{
    [Route("api/[controller]")]
    public class TripController : Controller
    {
        private IWorldRepository _repo;
        private ILogger<TripController> _logger;

        public TripController(IWorldRepository repository, ILogger<TripController> logger)
        {
            _repo = repository;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            
            return Json(Mapper.Map <IEnumerable< TripViewModel >> (_repo.GetAllTripsWithStops()));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        public String val { get; set; }
        
        /*   [FromBody]
            This is how [FromBody] attrib. works. You can only bind one element with this attribute. 
            Connection: keep-alive
            Origin: http://localhost:8000
            Accept: application/json, text/javascript,text/plain, *\/*; q=0.01
            Content-Type: application/x-www-form-urlencoded
            Host: localhost:8000
            Content-Length: 6

            =Adam
        */

        // POST api/values
        //[HttpPost(template:"{val}")]
        [HttpPost]
        public JsonResult Post([FromBody]TripViewModel val)
        {
            Debug.WriteLine("val:"+val.ToString());
            if (val == null)
            {
                return new JsonResult(new Exception("null value"));
            }

            if (!ModelState.IsValid)
            {
                return new JsonResult(new { Error="Model Falied",Detail=ModelState });
            }
            else {
                try
                {                   
                    Trip tripObject = AutoMapper.Mapper.Map<Trip>(val);
                    //_repo.SaveTrip(tripObject);
                    Request.HttpContext.Response.StatusCode = Microsoft.AspNet.Http.StatusCodes.Status201Created;
                    return new JsonResult("Success!"); ;
                }
                catch(Exception ex) {
                    _logger.LogError("Failid to save trip", ex);
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(new { error=ex});
                }               
                   
            }
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
