using AutoMapper;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using School.DB;
using School.Model;
using School.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace School.Controllers.API
{
    [Authorize]
    [Route("api/trips/{tripId}/stops")]
    public class StopController : Controller
    {
        private ILogger<StopController> _logger;
        private IWorldRepository _repo;

        public StopController(IWorldRepository repository, ILogger<StopController> logger)
        {
            _repo = repository;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult GetStops(int tripId)
        {
            var trip = _repo.GetTripWithStopsByTripId(tripId, User.Identity.Name);
            if (trip == null)
                return Json(null);
            return Json(Mapper.Map<IEnumerable<StopViewModel>>(trip.Destinations));
        }

        [HttpPost]
        public async Task<JsonResult> Post(int tripId, [FromBody]StopViewModel stopVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var stop = Mapper.Map<Stop>(stopVM);
                    string URI="http://maps.google.com/maps/api/geocode/json?address="+stop.Name+"&sensor=false";
                    HttpClient client = new HttpClient();
                   
                    var response = await client.GetAsync(URI);
                    var responseContent = response.Content;
                    var jsonGeo = await responseContent.ReadAsStringAsync();

                    _repo.GetTripWithStopsByTripId(tripId, User.Identity.Name).Destinations.Add(stop);

                    var json=new JsonResult(jsonGeo);
                    var obj=JObject.Parse(jsonGeo);
                    var lat=FindJObject(obj.Children(), "results[0].geometry.location.lat");
                    var lng = FindJObject(obj.Children(), "results[0].geometry.location.lng");
                    if (lat != null && lng != null)
                    {
                        stop.Latitude = lat.Values<double>().First();
                        stop.Longitude = lng.Values<double>().First();
                    }
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
                return Json(new { error = ModelState });
            }
        }

        public JToken FindJObject(JEnumerable<JToken> children, string key)
        {
            foreach (var child in children)
            {
                if (child.Path.Contains(key))
                    return child;
                JEnumerable<JToken> descendants = child.Children();
                if (descendants.Any())
                {
                    JToken found = FindJObject(descendants, key);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int tripId,int id)
        {
            try
            {
                _repo.DeleteStopById(id);
                _repo.SaveAll();
                return Json("OK");
            }
            catch (Exception e)
            {
                return Json("ERROR:" + e.Message??"");
            }
        }
    }
}
