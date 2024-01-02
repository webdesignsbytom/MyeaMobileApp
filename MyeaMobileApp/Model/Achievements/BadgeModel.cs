namespace MyeaMobileApp.Model
{
    public class BadgeModel
    {
        public string BadgeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAwarded { get; set; }
        public DateTime DateAwarded { get; set; }
    }
}
