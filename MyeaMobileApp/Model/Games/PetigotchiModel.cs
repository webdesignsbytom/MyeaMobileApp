namespace MyeaMobileApp.Model.Games
{
    public enum Mood { Happy, Sad, Excited, Bored, Neutral }

    public class PetigotchiModel
    {
        public string PetName { get; set; } = "Bentley";
        public string PetId { get; set; } = "f27a1a27-a266-4793-b5d2-6ae794356f9e";

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
        public int Hunger { get; set; } = 0;
        public int Happiness { get; set; } = 100;
        public int Health { get; set; } = 100;
        public int Cleanliness { get; set; } = 100;

        // 
        public DateTime LastFedTime { get; set; }

        // Postion on canvas
        public float Xpos { get; set; } = 100.0f;
        public float Ypos { get; set; } = 220.0f;

        public PetigotchiModel()
        {
            Xpos = 100.0f;
            Ypos = 220.0f;
        }

        public void UpdatePetPosition(float xPos, float yPos)
        {
            Xpos += xPos;
            Ypos += yPos;
        }        
        
        public void UpdatePetXPosition(float xPos)
        {
            Xpos += xPos;
        }   
        
        public void UpdatePetYPosition(float yPos)
        {
            Ypos += yPos;
        }
    }
}
