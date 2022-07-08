using BookingWebServices.Models;
using BookingWebServices.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Controllers
{
    [Route("api/1.0/flight/booking")]
    [ApiController]
    public class bookingController : ControllerBase
    {
        FightAirlineDBContext dbAirline;
        public bookingController(FightAirlineDBContext _dbAirline)
        {
            dbAirline = _dbAirline;
        }
        //[HttpPost]
        //public IActionResult postData(string flightId)
        //{
        //    //try
        //    //{
        //    //    TblAirline airline = new TblAirline();
        //    //    airline.AirlineName = airlineViewModel.AirlineName;
        //    //    airline.AirlineLogo = airlineViewModel.AirlineLogo;
        //    //    airline.Contact = airlineViewModel.Contact;
        //    //    airline.Address = airlineViewModel.Address;
        //    //    dbAirline.TblAirlines.Add(airline);
        //    //    dbAirline.SaveChanges();
        //    //    return Ok("Record Added Successfully");
        //    //}
        //    //catch
        //    //{
        //    //    return BadRequest();
        //    //}
        //    return Ok();
        //}
        [HttpPost]
        public IActionResult postUserData(UserViewModel userViewModel)
        {
            try
            {
                TblUser user = new TblUser();
                user.AirlineName = userViewModel.AirlineName;
                user.FlightNumber = userViewModel.FlightNumber;
                user.UserName = userViewModel.UserName;
                user.EmailId = userViewModel.EmailId;
                user.Gender = userViewModel.Gender;
                user.Age = userViewModel.Age;
                user.NoOfSeats = userViewModel.NoOfSeats;
                user.SeatsNumbers = userViewModel.SeatsNumbers;
                user.Meal = userViewModel.Meal;
                user.Pnr = userViewModel.Pnr;
                user.Cancelled = userViewModel.Cancelled;
                dbAirline.TblUsers.Add(user);
                dbAirline.SaveChanges();
                return Ok("Record Added Successfully");
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpGet]
        public IActionResult history(string emailId)
        {
            try
            {
                var data = dbAirline.TblUsers;
                List<TblUser> lst = new List<TblUser>();
                foreach (var dr in data)
                {
                    if (dr.EmailId == emailId)
                    {
                        lst.Add(dr);
                    }
                }
                return Ok(lst);
            }
            catch
            {
                return BadRequest();

            }
           
        }
        [HttpDelete]
        public IActionResult cancel(int pnr)
        {
            try
            {
                if (dbAirline.TblUsers.Any(x => x.Pnr == pnr))
                {
                    var data = dbAirline.TblUsers.Where(x => x.Pnr == pnr).FirstOrDefault();
                    dbAirline.TblUsers.Remove(data);
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

    }
}
