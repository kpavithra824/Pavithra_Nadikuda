using AirlineMicroServices.Models;
using AirlineMicroServices.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMicroServices.Controllers
{
    [Route("api/1.0/flight/airline/Inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        FightAirlineDBContext dbAirline;
        public InventoryController(FightAirlineDBContext _dbAirline)
        {
            dbAirline = _dbAirline;
        }
        [Route("add")]
        [HttpPost]
        public IActionResult add(FlightViewModel flightViewModel)
        {
            try
            {
                TblFlightSchedule addflight = new TblFlightSchedule();
                addflight.AirlineId = flightViewModel.AirlineId;
                addflight.AirlineName = flightViewModel.AirlineName;
                addflight.AirlineLogo = flightViewModel.AirlineLogo;
                addflight.FlightNumber = flightViewModel.FlightNumber;
                addflight.FromPlace = flightViewModel.FromPlace;
                addflight.ToPlace = flightViewModel.ToPlace;
                addflight.StartDatetime = flightViewModel.StartDatetime;
                addflight.EndDatetime = flightViewModel.EndDatetime;                
                addflight.BusinessClassSeats = flightViewModel.BusinessClassSeats;
                addflight.NonBusinessClassSeats = flightViewModel.NonBusinessClassSeats;
                addflight.TicketPrice = flightViewModel.TicketPrice;
                addflight.InstrumentUsed = flightViewModel.InstrumentUsed;
                addflight.Meal = flightViewModel.Meal;
                addflight.NoOfRows = flightViewModel.NoOfRows;
                addflight.ScheduleDays = flightViewModel.ScheduleDays;
                dbAirline.TblFlightSchedules.Add(addflight);
                dbAirline.SaveChanges();
                return Ok("Record Added Successfully");
            }
            catch 
            {
                return BadRequest("Record Save Failed");
            }          
        }

        [HttpPut]
        public IActionResult putData(FlightViewModel flightViewModel)
        {
            try
            {
                if (dbAirline.TblFlightSchedules.Any(x => x.FlightId == flightViewModel.FlightId))
                {
                    var data = dbAirline.TblFlightSchedules.Where(x => x.AirlineId == flightViewModel.AirlineId).FirstOrDefault();
                    data.AirlineId = flightViewModel.AirlineId;
                    data.AirlineName = flightViewModel.AirlineName;
                    data.AirlineLogo = flightViewModel.AirlineLogo;
                    data.FlightNumber = flightViewModel.FlightNumber;
                    data.FromPlace = flightViewModel.FromPlace;
                    data.ToPlace = flightViewModel.ToPlace;
                    data.StartDatetime = flightViewModel.StartDatetime;
                    data.EndDatetime = flightViewModel.EndDatetime;
                    data.BusinessClassSeats = flightViewModel.BusinessClassSeats;
                    data.NonBusinessClassSeats = flightViewModel.NonBusinessClassSeats;
                    data.TicketPrice = flightViewModel.TicketPrice;
                    data.InstrumentUsed = flightViewModel.InstrumentUsed;
                    data.Meal = flightViewModel.Meal;
                    data.NoOfRows = flightViewModel.NoOfRows;
                    data.ScheduleDays = flightViewModel.ScheduleDays;
                    dbAirline.TblFlightSchedules.Update(data);
                    dbAirline.SaveChanges();
                    return Ok("Record have been successfully updated.");
                }

                return BadRequest("Record not found.");
            }
            catch
            {
                return BadRequest("Record Update Failed ");
            }                  
        }

        [HttpDelete]
        public IActionResult deleteData(int flightId)
        {
            try 
            {
                if (dbAirline.TblFlightSchedules.Any(x => x.FlightId == flightId))
                {
                    var data = dbAirline.TblFlightSchedules.Where(x => x.FlightId == flightId).FirstOrDefault();
                    dbAirline.TblFlightSchedules.Remove(data);
                    dbAirline.SaveChanges();
                    return Ok("Record have been successfully deleted.");
                }

                return BadRequest("Record not found.");
            }
            catch 
            {
                return BadRequest("Record Delete Failed");
            }         
        }
    }
}
