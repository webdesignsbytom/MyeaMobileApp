namespace MyeaMobileApp.Model.Lottery
{
    public class LotteryTicketModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public List<int> SelectedNumbers { get; set; } = new();
        public int BonusBall { get; set; }

        public DateTime PuchaseDate { get; set; }
    }
}
