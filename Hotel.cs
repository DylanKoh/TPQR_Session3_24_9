//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPQR_Session3_24_9
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            this.Hotel_Booking = new HashSet<Hotel_Booking>();
        }
    
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public int singleRate { get; set; }
        public int doubleRate { get; set; }
        public int numSingleRoomsTotal { get; set; }
        public int numDoubleRoomsTotal { get; set; }
        public int numSingleRoomsBooked { get; set; }
        public int numDoubleRoomsBooked { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hotel_Booking> Hotel_Booking { get; set; }
    }
}
