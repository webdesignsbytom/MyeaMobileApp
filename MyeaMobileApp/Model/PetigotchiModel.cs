namespace MyeaMobileApp.Model
{
    public class PetigotchiModel
    {
        public string PetName { get; set; } = "Dennis";
        public float Xpos { get; set; }
        public float Ypos { get; set; }

        public PetigotchiModel(int xpos, int ypos)
        {
            Xpos = xpos;
            Ypos = ypos;
        }
    }
}
