//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelReservation.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Rate { get; set; }
        public string RoomType { get; set; }
        public int HotelId { get; set; }
    
        public virtual Hotel Hotel { get; set; }
    }
}
