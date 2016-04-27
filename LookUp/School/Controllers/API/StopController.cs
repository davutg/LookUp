using AutoMapper;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using School.DB;
using School.Model;
using School.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers.API
{
    [Authorize]
    [Route("api/trips/{tripId}/stops")]
    public class StopController:Controller
    {
        private ILogger<StopController> _logger;
        private IWorldRepository _repo;

        public StopController(IWorldRepository repository,ILogger<StopController> logger)
        {
            _repo = repository;
            _logger = logger;                    
        }

        [HttpGet]
        public JsonResult GetStops(int tripId)
        {
            var trip=_repo.GetTripWithStopsByTripId(tripId,User.Identity.Name);
            if (trip == null)
                return Json(null);
            return Json(Mapper.Map<IEnumerable<StopViewModel>>(trip.Destinations));
        }

        [HttpPost]
        public JsonResult Post(int tripId, [FromBody]StopViewModel stopVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var stop = Mapper.Map<Stop>(stopVM);                    
                    _repo.GetTripWithStopsByTripId(tripId,User.Identity.Name).Destinations.Add(stop);
                    if (_repo.SaveAll())
                    {
                        Response.StatusCode = StatusCodes.Status200OK;
                        return Json(Mapper.Map<StopViewModel>(stop));
                    }
                    else {
                        Response.StatusCode = StatusCodes.Status500InternalServerError;
                        return Json(false);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return Json(e);
                }
            }
            else
            {
                return Json(new { error=ModelState});
            }
        }

    }
}
