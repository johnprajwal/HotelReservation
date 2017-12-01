using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business = HotelReservation.Business;

namespace HotelReservation.Test
{
    [TestClass]
    public class Hotel
    {
        [TestMethod]
        public void GetAllHotels()
        {
            Business.Hotel hotel = new Business.Hotel();

            var data = hotel.GetAllHotels();

            Assert.IsNotNull(data);
         }
    }
}
