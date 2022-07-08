using AirlineMicroServices.Models;
using AirlineMicroServices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMicroServices.Controllers
{
    [Route("api/1.0/flight/airline")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        FightAirlineDBContext dbAirline;

        public RegisterController(FightAirlineDBContext _dbAirline)
        {
            dbAirline = _dbAirline;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(AirlineViewModel airlineViewModel)
        {
            try
            {
                TblAirline airline = new TblAirline();
                airline.AirlineName = airlineViewModel.AirlineName;
                airline.AirlineLogo = airlineViewModel.AirlineLogo;
                airline.Contact = airlineViewModel.Contact;
                airline.Address = airlineViewModel.Address;
                dbAirline.TblAirlines.Add(airline);
                dbAirline.SaveChanges();
                return Ok("Record Added Successfully");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]      
        public IActionResult putData(AirlineViewModel airlineViewModel)
        {
            try 
            {
                if (dbAirline.TblAirlines.Any(x => x.AirlineId == airlineViewModel.AirlineId))
                {
                    var data = dbAirline.TblAirlines.Where(x => x.AirlineId == airlineViewModel.AirlineId).FirstOrDefault();
                    data.AirlineName = airlineViewModel.AirlineName;
                    data.Contact = airlineViewModel.Contact;
                    data.Address = airlineViewModel.Address;
                    data.AirlineLogo = airlineViewModel.AirlineLogo;
                    dbAirline.TblAirlines.Update(data);
                    dbAirline.SaveChanges();
                    return Ok("Record have been successfully updated.");
                }

                return BadRequest("Record not found.");
            }
            catch
            {
                return BadRequest("Record Update Failed.");
            }
            
        }

        [HttpDelete]      
        public IActionResult deleteData(int Id)
        {
            try 
            {
                if (dbAirline.TblAirlines.Any(x => x.AirlineId == Id))
                {
                    var data = dbAirline.TblAirlines.Where(x => x.AirlineId == Id).FirstOrDefault();
                    dbAirline.TblAirlines.Remove(data);
                    dbAirline.SaveChanges();
                    return Ok("Record have been successfully deleted.");
                }

                return BadRequest("Record not found.");
            }
            catch
            {
                return BadRequest("Record Delete Failed.");
            }
           
        }


        
        //[HttpGet]      
        
        //public string getData()
        //{
        //    return "OK";
        //}



        //public List<TblAirline> FindAll()
        //{
        //    return dbAirline.TblAirlines.ToList();
        //}
    }
}
