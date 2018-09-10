namespace Assignment2
{
    public class NewPlayer
    {
        public string Name { get; set; }

        public NewPlayer (string playerName)
        {
            Name = playerName;


        } 
        public static implicit operator NewPlayer(string player){
            return new NewPlayer(player);
        }
    }
}