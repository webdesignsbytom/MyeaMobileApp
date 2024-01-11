namespace MyeaMobileApp.Model.Games
{
    public enum Mood { Happy, Sad, Excited, Bored, Neutral }

    public class PetigotchiModel
    {
        public string PetName { get; set; } = "Fluffy";
        public float Xpos { get; set; }
        public float Ypos { get; set; }

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
        public int Hunger { get; private set; }
        public int Happiness { get; private set; }
        public int Health { get; private set; }
        public int Cleanliness { get; private set; }

        // 
        public DateTime LastFedTime { get; set; }


        public PetigotchiModel(int xpos, int ypos)
        {
            Xpos = xpos;
            Ypos = ypos;
        }
    }
}
