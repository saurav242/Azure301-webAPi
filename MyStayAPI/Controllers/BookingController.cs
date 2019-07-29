using Agent.Interface;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStayAPI.Controllers
{
    [Route("api/booking")]
    public class BookingController : Controller
    {
        private readonly IBookingAgent _bookingAgent;

        public BookingController(IBookingAgent bookingAgent)
        {
            _bookingAgent = bookingAgent;
        }

        [HttpGet("{id}", Name = "GetBookingsByID")]
        public IActionResult GetBookingsByID(int bookingID)
        {
            return Ok(_bookingAgent.GetBookingsByID(bookingID));
        }

        [HttpGet("hotel/{id}")]
        public IActionResult GetBookingsByHotelID(int hotelID)
        {
            return Ok(_bookingAgent.GetBookingsByHotelID(hotelID));
        }

        [HttpGet("user/{id}")]
        public IActionResult GetBookingsByUserID(int UserID)
        {
            return Ok(_bookingAgent.GetBookingsByUserID(UserID));
        }
        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                if (booking == null)
                {
                    return BadRequest("Booking object is null");
                }
                _bookingAgent.CreateBooking(booking);
                return CreatedAtRoute("GetBookingsByID", new { id = booking.Id }, booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
