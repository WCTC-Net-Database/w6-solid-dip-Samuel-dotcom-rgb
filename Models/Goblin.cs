namespace W06.Models
{
    public class Goblin : CharacterBase, ILootable
    {
        public string Treasure { get; set; }

        public Goblin(string name, string type, int level, int hp, string treasure)
            : base(name, type, level, hp)
        {
            Treasure = treasure;
        }

        /// <summary>
        /// Goblin's special action - a sneaky backstab!
        /// This is required because CharacterBase defines it as abstract.
        /// </summary>
        public override void PerformSpecialAction()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} performs a sneaky backstab!");
            Console.ResetColor();
        }
    }

    public interface ILootable
    {
        string Treasure { get; set; }
    }
}
