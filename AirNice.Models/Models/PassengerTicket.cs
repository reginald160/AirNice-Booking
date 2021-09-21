using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
	public partial class PassengerTicket : BaseModel
	{
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string IDCardOrPassport { get; set; }
        public DateTime? DateIssueOrExpiry { get; set; }
        public string PlaceIssue { get; set; }
        public DateTime? Birthday { get; set; }
        public Guid? PassengerTypeId { get; set; }
        [JsonIgnore]
        [ForeignKey("PassengerTypeId")]
        public virtual PassengerType PassengerType { get; set; }
		public Guid? TicketId { get; set; }
        [JsonIgnore]
        [ForeignKey("TicketId")]
		public virtual Ticket Ticket { get; set; }
    }
}