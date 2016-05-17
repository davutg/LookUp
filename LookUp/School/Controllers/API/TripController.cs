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
using Microsoft.AspNet.Authorization;
using School.Helpers;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860


namespace School.Controllers.API
{
    [Authorize]
    [Route("api/[controller]")]
    [NoCache]
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
            
            return Json(Mapper.Map <IEnumerable< TripViewModel >> (_repo.GetAllTripsWithStops(User.Identity.Name)));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_repo.GetTripWithStopsByTripId(id,User.Identity.Name));            
        }

        public String val { get; set; }
        
        public IMapper Mapper
        {
            get {
                return AutoMapper.Mapper.Instance;
            }
        }

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
                    tripObject.UserName = User.Identity.Name;
                    _repo.AddTrip(tripObject);
                    if (_repo.SaveAll())
                    {
                        Request.HttpContext.Response.StatusCode = Microsoft.AspNet.Http.StatusCodes.Status201Created;
                        return Json(Mapper.Map<TripViewModel>(tripObject));
                    }
                    else
                    {
                        Response.StatusCode =(int)HttpStatusCode.InternalServerError;
                        return Json(val);
                    }
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
        public JsonResult Put(int id, [FromBody]TripViewModel tripVM)
        {
            var trip=Mapper.Map<Trip>(tripVM);
            trip.UserName = User.Identity.Name;
            _repo.UpdateTrip(trip);
            if (_repo.SaveAll())
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(tripVM);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(tripVM);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _repo.DeleteTripById(id);
            if (_repo.SaveAll())
            {
                Response.StatusCode = Microsoft.AspNet.Http.StatusCodes.Status204NoContent;
                return Json(true);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(false);
            }
        }
    }
}
