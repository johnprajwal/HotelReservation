using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Common;
using DAL = HotelReservation.Data;

namespace HotelReservation.Business
{
    public sealed class Hotel
    {
        private ICrudService<DAL.Hotel> _service;

        public Hotel()
        {
            _service = new CrudService<DAL.Hotel>(new DAL.hoteldbEntities());
        }
        public List<DAL.Hotel> GetAllHotels()
        {
            return _service.GetAll().ToList< DAL.Hotel>();
        }
    }
}
