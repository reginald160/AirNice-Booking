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


        public enum Adult
        {
            [Display(Name ="1")] one =1 , [Display(Name = "2")] two =2, [Display(Name = "3")] three = 3,
            [Display(Name = "4")] four = 4, [Display(Name = "5")] five =5, [Display(Name = "6")] six =6, 
            [Display(Name = "7")] seven =7, [Display(Name = "8")] eight = 8, [Display(Name = "9")] nine =9, [Display(Name = "10")] ten =10
        }
        public enum Children
        {
            [Display(Name = "1")] one = 1, [Display(Name = "2")] two = 2, [Display(Name = "3")] three = 3,
            [Display(Name = "4")] four = 4, [Display(Name = "5")] five = 5, [Display(Name = "6")] six = 6,
            [Display(Name = "7")] seven = 7, [Display(Name = "8")] eight = 8, [Display(Name = "9")] nine = 9, [Display(Name = "10")] ten = 10
        }

        public enum FlightCategory
    {

    }
        }
       
}
