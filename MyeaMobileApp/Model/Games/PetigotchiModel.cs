namespace MyeaMobileApp.Model.Games
{
    public enum Mood { Happy, Sad, Excited, Bored, Neutral }

    public class PetigotchiModel
    {
        public string PetName { get; set; } = "Bentley";
        public double Xpos { get; set; }
        public double Ypos { get; set; }

        // Pet stats
        public bool PetIsAlive { get; set; } = true;
        public Mood PetMood { get; set; } = Mood.Happy;

        // Health stats
        public bool PetIsSick { get; set; } = false;
        public bool PetIsInjured { get; set; } = false;
        public bool PetIsHungry { get; set; } = false;
        public bool PetIsAsleep { get; set; } = false;
        public bool PetIsTired { get; set; } = false;
        public bool PetIsDirty { get; set; } = false;

        // Basic attributes
        public int Hunger { get; set; } = 100;
        public int Happiness { get; set; } = 100;
        public int Health { get; set; } = 100;
        public int Cleanliness { get; set; } = 100;

        // 
        public DateTime LastFedTime { get; set; }

        public PetigotchiModel()
        {
        }

        public void UpdatePetigotchiPosition(double xpos, double ypos)
        {
            Xpos = xpos;
            Ypos = ypos;
        }
    }
}
