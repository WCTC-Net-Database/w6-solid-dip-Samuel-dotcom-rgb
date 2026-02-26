namespace W06.Models
{
    public class Player : CharacterBase
    {
        public int Gold { get; set; }

        public Player(string name, string type, int level, int hp, int gold)
            : base(name, type, level, hp)
        {
            Gold = gold;
        }

        /// <summary>
        /// Player's special action - a powerful sword strike!
        /// This is required because CharacterBase defines it as abstract.
        /// </summary>
        public override void PerformSpecialAction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} performs a powerful sword strike!");
            Console.ResetColor();
        }
    }
}
