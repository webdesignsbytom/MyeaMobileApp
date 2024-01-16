namespace MyeaMobileApp.Model.Events
{
    public class PlannedEventModel
    {
        public string UserId { get; set; }
        public string EventTitle { get; set; }
        public string EventInfo { get; set; }
        public string EventLocation { get; set; }
        public string ImageUrl { get; set; }
        public DateTime EventDate { get; set; }

        public override string ToString()
        {
            return $"UserId: {UserId}, EventTitle: {EventTitle}, EventInfo: {EventInfo}, EventLocation: {EventLocation}, ImageUrl: {ImageUrl}, EventDate: {EventDate}";
        }
    }
}
