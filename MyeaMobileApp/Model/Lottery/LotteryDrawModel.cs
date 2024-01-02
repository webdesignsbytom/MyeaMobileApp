using System;
using System.Collections.Generic;

namespace MyeaMobileApp.Model.Lottery
{
    public class LotteryDrawModel
    {
        public string Id { get; set; }
        public decimal Prize { get; set; }
        public List<LotteryTicketModel> Tickets { get; set; } = new List<LotteryTicketModel>();
        public int TicketsSold { get; set; }
        public bool TicketsAreOnSale { get; set; }
        public bool WinnerFound { get; set; }
        public DateTime DrawDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
