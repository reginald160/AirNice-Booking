using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirNice.Models
{  
    public class Enum
    { 

    public enum BookingEnquiryType
    {
        Cashual, Reserve
    }

    public enum AirLinesEnquiryType
    {
        Flight,DepartureTime
    }

    public enum TicketClassType
    {
        Economy,FirstClass
    }

    public enum BookingType
    {
        FirstClass,Premium, Economy
    }

    public enum PassengerCategory
    {
        Adult, Child, Infant
    }
    
    public enum TripType
    {
        [Display(Name ="One way Rip")]
        Oneway,
        [Display(Name ="Round trip")]
        RoundTrip
    }

    public enum FlightCategory
    {

    }
        }
       
}
