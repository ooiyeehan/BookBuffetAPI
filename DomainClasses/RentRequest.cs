using System;
using System.Collections.Generic;

#nullable disable

namespace BookBuffetWeb2.DomainClasses
{
    public partial class RentRequest
    {
        public int Id { get; set; }
        public string RequesterId { get; set; }
        public string ReceiverId { get; set; }
        public int BookId { get; set; }
        public string RequestDate { get; set; }
        public string Status { get; set; }
    }
}
