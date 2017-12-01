using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business = HotelReservation.Business;
using Models = HotelReservation.Models;
using Data = HotelReservation.Data;

namespace HotelReservation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Message = "List of Hotels";

            var model = GetHotels();

            return View(model);
        }

        private List<Models.Hotel> GetHotels()
        {
            Business.Hotel hotels = new Business.Hotel();

            var data = hotels.GetAllHotels().ToList<Data.Hotel>();

            List<Models.Hotel> modelHotels = new List<Models.Hotel>();

            if (data != null)
            {
                data.ForEach(d =>
                {
                    modelHotels.Add(new Models.Hotel()
                    {
                        Address = d.Address,
                        City = d.City,
                        Country = d.Country,
                        Id = d.Id,
                        Name = d.Name,
                        State = d.State,
                        Zip = d.Zip,
                        Rooms = GetRooms(d.Rooms)
                    });


                });

            }

            return modelHotels;
        }

        private ICollection<Models.Room> GetRooms(ICollection<Data.Room> rooms)
        {
            List<Models.Room> lstRooms = null;
            if (rooms != null)
            {
                lstRooms = new List<Models.Room>();
                foreach (var room in rooms)
                {
                    lstRooms.Add(new Models.Room()
                    {
                        HotelId = room.HotelId,
                        Id = room.Id,
                        Number = room.Number,
                        Rate = room.Rate,
                        RoomType = room.RoomType
                    });
                }
            }
            return lstRooms;
        }
    }
}
