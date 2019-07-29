using Agent.Interface;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStayAPI.Controllers
{
    [Route("api/hotel")]
    public class HotelController : Controller
    {
        private readonly IHotelAgent _hotelAgent;
        private readonly IHotelRoomAgent _hotelRoomAgent;

        public HotelController(IHotelAgent hotelAgent, IHotelRoomAgent hotelRoomAgent)
        {
            _hotelAgent = hotelAgent;
            _hotelRoomAgent = hotelRoomAgent;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns> All the Hotels</returns>
        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAllHotel()
        {
            try
            {
                var hotel = _hotelAgent.GetAllHotel();

                return Ok(hotel);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetHotelById")]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var hotel = _hotelAgent.GetHotelByID(id);

                return Ok(hotel);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/room")]
        public IActionResult GetHotelRoom(int id)
        {
            try
            {
                var hotel = _hotelRoomAgent.GetRoomForHotel(id);

                return Ok(hotel);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("city/{city}")]
        public IActionResult GetHotelByCity(string city)
        {
            try
            {
                var hotel = _hotelAgent.GetHotelByCity(city);

                return Ok(hotel);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                if (hotel == null)
                {
                    return BadRequest("Hotel object is null");
                }
                _hotelAgent.CreateHotel(hotel);
                return CreatedAtRoute("GetHotelById", new { id = hotel.Id }, hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
