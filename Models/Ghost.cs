using W06.Interfaces;

namespace W06.Models
{
    public class Ghost : CharacterBase, IFlyable
    {
        public string Treasure { get; set; }

        public Ghost(string name, string type, int level, int hp, string treasure)
            : base(name, type, level, hp)
        {
            Treasure = treasure;
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} flies rapidly through the air.");
        }

        /// <summary>
        /// Ghost's special action - phases through walls!
        /// This is required because CharacterBase defines it as abstract.
        /// </summary>
        public override void PerformSpecialAction()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Name} phases through the walls!");
            Console.ResetColor();
        }
    }
}
