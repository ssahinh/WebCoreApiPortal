using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCoreApiPortal.Models;
using WebCoreApiPortal.Models.MyContext;
using WebCoreApiPortal.Models.Response;
using WebCoreApiPortal.Utils;

namespace WebCoreApiPortal.Controllers
{
    /// <summary>
    /// PARK KIT Services
    /// </summary>
    [Produces("application/json")]
    [Route("parkkit")]
    [ApiController]
    public class ParkkitController : ControllerBase
    {
        private PortalDbContext db;

        public ParkkitController()
        {
            db = new PortalDbContext();
        }

        /// <summary>
        /// Tüm Otopark Noktalarını Getirir.
        /// </summary>
        /// <returns>Park Listesi</returns>
        /// <response code="200"></response> 
        [HttpGet("autopark")]
        [ProducesResponseType(typeof(ParkkitResponseModel), StatusCodes.Status200OK)]
        public IActionResult GetAutoPark()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = db.Parkkits.Where(p => p.Type == Common.OTOPARK).ToList();
                if (result == null && result.Count == 0)
                {
                    return NotFound();
                }

                var response = new ParkkitResponseModel
                {
                    code = "Success",
                    message = "İşlem Başarıyla Gerçekleşti.",
                    data = result
                };

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Koordinat sistemine göre belli bir mesafedeki otopark noktalarını getirir. 
        /// </summary>
        /// <param name="distance">Mesafe</param>
        /// <param name="lat">x ekseni</param>
        /// <param name="lng">y ekseni</param>
        /// <returns></returns>
        [HttpGet("distpark")]
        [ProducesResponseType(typeof(ParkkitResponseModel), StatusCodes.Status200OK)]
        public IActionResult GetAutoParkByDistance(string distance, string lat, string lng)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = db.Parkkits.Where(p => p.Type == Common.OTOPARK).ToList();
                if (data == null && data.Count == 0)
                {
                    return NotFound();
                }

                List<Parkkit> parkList = new List<Parkkit>();
                double dist = 0;
                double XCoor = Convert.ToDouble(lat);
                double YCoor = Convert.ToDouble(lng);
                double space = Convert.ToDouble(distance) / 1000;

                foreach (var item in data)
                {
                    double XCoorItem = item.XCoor;
                    double YCoorItem = item.YCoor;

                    dist = MapyHelper.distanceTwoPoints(XCoor, YCoor, XCoorItem, YCoorItem, "K");

                    if (dist < space)
                    {
                        parkList.Add(new Parkkit
                        {
                            Id = item.Id,
                            Address = item.Address,
                            Brand = item.Brand,
                            City = item.City,
                            Code = item.Code,
                            Name = item.Name,
                            Neighborhood = item.Neighborhood,
                            Postcode = item.Postcode,
                            Town = item.Town,
                            Type = item.Type,
                            XCoor = item.XCoor,
                            YCoor = item.YCoor,
                            Distance = dist
                        });
                    }

                }

                var response = new ParkkitResponseModel
                {
                    code = "Success",
                    message = "İşlem Başarıyla Gerçekleşti.",
                    data = parkList.OrderBy(x => x.Distance).ToList()
                };

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Koordinat sistemine göre belli bir mesafedeki benzin istasyon noktalarını getirir. 
        /// </summary>
        /// <param name="distance">Mesafe</param>
        /// <param name="lat">x ekseni</param>
        /// <param name="lng">y ekseni</param>
        /// <returns></returns>
        [HttpGet("distgasstation")]
        [ProducesResponseType(typeof(ParkkitResponseModel), StatusCodes.Status200OK)]
        public IActionResult GetGasStationByDistance(string distance, string lat, string lng)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = db.Parkkits.Where(p => p.Type == Common.BENZIN).ToList();
                if (data == null && data.Count == 0)
                {
                    return NotFound();
                }

                List<Parkkit> parkList = new List<Parkkit>();
                double dist = 0;
                double XCoor = Convert.ToDouble(lat);
                double YCoor = Convert.ToDouble(lng);
                double space = Convert.ToDouble(distance) / 1000;

                foreach (var item in data)
                {
                    double XCoorItem = item.XCoor;
                    double YCoorItem = item.YCoor;

                    dist = MapyHelper.distanceTwoPoints(XCoor, YCoor, XCoorItem, YCoorItem, "K");

                    if (dist < space)
                    {
                        parkList.Add(new Parkkit
                        {
                            Id = item.Id,
                            Address = item.Address,
                            Brand = item.Brand,
                            City = item.City,
                            Code = item.Code,
                            Name = item.Name,
                            Neighborhood = item.Neighborhood,
                            Postcode = item.Postcode,
                            Town = item.Town,
                            Type = item.Type,
                            XCoor = item.XCoor,
                            YCoor = item.YCoor,
                            Distance = dist
                        });
                    }

                }

                var response = new ParkkitResponseModel
                {
                    code = "Success",
                    message = "İşlem Başarıyla Gerçekleşti.",
                    data = parkList.OrderBy(x => x.Distance).ToList()
                };

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Koordinat sistemine göre belli bir mesafedeki banka-atm noktalarını getirir. 
        /// </summary>
        /// <param name="distance">Mesafe</param>
        /// <param name="lat">x ekseni</param>
        /// <param name="lng">y ekseni</param>
        /// <returns></returns>
        [HttpGet("distbankatm")]
        [ProducesResponseType(typeof(ParkkitResponseModel), StatusCodes.Status200OK)]
        public IActionResult GetBankAtmByDistance(string distance, string lat, string lng)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var types = new string[] { Common.ATM, Common.BANKA };

                var data = db.Parkkits.Where(p => types.Contains(p.Type)).ToList();
                if (data == null && data.Count == 0)
                {
                    return NotFound();
                }

                List<Parkkit> parkList = new List<Parkkit>();
                double dist = 0;
                double XCoor = Convert.ToDouble(lat);
                double YCoor = Convert.ToDouble(lng);
                double space = Convert.ToDouble(distance) / 1000;

                foreach (var item in data)
                {
                    double XCoorItem = item.XCoor;
                    double YCoorItem = item.YCoor;

                    dist = MapyHelper.distanceTwoPoints(XCoor, YCoor, XCoorItem, YCoorItem, "K");

                    if (dist < space)
                    {
                        parkList.Add(new Parkkit
                        {
                            Id = item.Id,
                            Address = item.Address,
                            Brand = item.Brand,
                            City = item.City,
                            Code = item.Code,
                            Name = item.Name,
                            Neighborhood = item.Neighborhood,
                            Postcode = item.Postcode,
                            Town = item.Town,
                            Type = item.Type,
                            XCoor = item.XCoor,
                            YCoor = item.YCoor,
                            Distance = dist
                        });
                    }

                }

                var response = new ParkkitResponseModel
                {
                    code = "Success",
                    message = "İşlem Başarıyla Gerçekleşti.",
                    data = parkList.OrderBy(x => x.Distance).ToList()
                };

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Koordinat sistemine göre belli bir mesafedeki oto yıkama noktalarını getirir. 
        /// </summary>
        /// <param name="distance">Mesafe</param>
        /// <param name="lat">x ekseni</param>
        /// <param name="lng">y ekseni</param>
        /// <returns></returns>
        [HttpGet("distcarwash")]
        [ProducesResponseType(typeof(CarWishResponseModel), StatusCodes.Status200OK)]
        public IActionResult GetCarWashByDistance(string distance, string lat, string lng)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = db.CarWashes.ToList();

                if (data == null && data.Count == 0)
                {
                    return NotFound();
                }

                List<CarWash> parkList = new List<CarWash>();
                double dist = 0;
                double XCoor = Convert.ToDouble(lat);
                double YCoor = Convert.ToDouble(lng);
                double space = Convert.ToDouble(distance) / 1000;

                foreach (var item in data)
                {
                    double XCoorItem = item.XCoor;
                    double YCoorItem = item.YCoor;

                    dist = MapyHelper.distanceTwoPoints(XCoor, YCoor, XCoorItem, YCoorItem, "K");

                    if (dist < space)
                    {
                        parkList.Add(new CarWash
                        {
                            Id = item.Id,
                            Address = item.Address,
                            Brand = item.Brand,
                            City = item.City,
                            Code = item.Code,
                            Name = item.Name,
                            Neighborhood = item.Neighborhood,
                            Postcode = item.Postcode,
                            Town = item.Town,
                            Type = item.Type,
                            XCoor = item.XCoor,
                            YCoor = item.YCoor,
                            Distance = dist
                        });
                    }

                }

                var response = new CarWishResponseModel
                {
                    code = "Success",
                    message = "İşlem Başarıyla Gerçekleşti.",
                    data = parkList.OrderBy(x => x.Distance).ToList()
                };

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Koordinat sistemine göre belli bir mesafedeki otoservis noktalarını getirir. 
        /// </summary>
        /// <param name="distance">Mesafe</param>
        /// <param name="lat">x ekseni</param>
        /// <param name="lng">y ekseni</param>
        /// <returns></returns>
        [HttpGet("distcarservice")]
        [ProducesResponseType(typeof(CarServiceResponseModel), StatusCodes.Status200OK)]
        public IActionResult GetAutoServiceByDistance(string distance, string lat, string lng)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = db.CarServices.ToList();
                if (data == null && data.Count == 0)
                {
                    return NotFound();
                }

                List<CarService> parkList = new List<CarService>();
                double dist = 0;
                double XCoor = Convert.ToDouble(lat);
                double YCoor = Convert.ToDouble(lng);
                double space = Convert.ToDouble(distance) / 1000;

                foreach (var item in data)
                {
                    double XCoorItem = item.XCoor;
                    double YCoorItem = item.YCoor;

                    dist = MapyHelper.distanceTwoPoints(XCoor, YCoor, XCoorItem, YCoorItem, "K");

                    if (dist < space)
                    {
                        parkList.Add(new CarService
                        {
                            Id = item.Id,
                            Address = item.Address,
                            Brand = item.Brand,
                            City = item.City,
                            Code = item.Code,
                            Name = item.Name,
                            Neighborhood = item.Neighborhood,
                            Postcode = item.Postcode,
                            Town = item.Town,
                            Type = item.Type,
                            XCoor = item.XCoor,
                            YCoor = item.YCoor,
                            Distance = dist
                        });
                    }

                }

                var response = new CarServiceResponseModel
                {
                    code = "Success",
                    message = "İşlem Başarıyla Gerçekleşti.",
                    data = parkList.OrderBy(x => x.Distance).ToList()
                };

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }






        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
