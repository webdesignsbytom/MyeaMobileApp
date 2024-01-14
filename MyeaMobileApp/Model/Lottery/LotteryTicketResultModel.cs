namespace MyeaMobileApp.Model.Lottery
{
    public class LotteryTicketResultModel
    {
        public List<int> SelectedNumbers { get; set; } = new();
        public int BonusBall { get; set; }
        public Color BackgroundColor { get; set; }

    }
}
