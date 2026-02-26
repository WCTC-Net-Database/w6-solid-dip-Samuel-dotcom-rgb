using W06.Interfaces;

namespace W06.Models
{
    public abstract class CharacterBase : ICharacter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }

        protected CharacterBase(string name, string type, int level, int hp)
        {
            Name = name;
            Type = type;
            Level = level;
            HP = hp;
        }

        protected CharacterBase() { }

        public void Attack(ICharacter target)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} attacks {target.Name}");
            Console.ResetColor();

            if (this is Player player && target is ILootable targetWithTreasure && !string.IsNullOrEmpty(targetWithTreasure.Treasure))
            {
                Console.WriteLine($"{Name} takes {targetWithTreasure.Treasure} from {target.Name}");
                player.Gold += 10; // Assuming each treasure is worth 10 gold
                targetWithTreasure.Treasure = null; // Treasure is taken
            }
            else if (this is Player playerWithGold && target is Player targetWithGold && targetWithGold.Gold > 0)
            {
                Console.WriteLine($"{Name} takes gold from {target.Name}");
                playerWithGold.Gold += targetWithGold.Gold;
                targetWithGold.Gold = 0; // Gold is taken
            }
        }

        public void Move()
        {
            Console.WriteLine($"{Name} moves.");
        }

        /// <summary>
        /// Abstract method - derived classes MUST implement this.
        ///
        /// This is a key DIP concept: the base class defines WHAT should happen,
        /// but derived classes decide HOW it happens.
        ///
        /// Examples:
        /// - Player might perform a "Power Strike"
        /// - Goblin might perform a "Sneak Attack"
        /// - Ghost might perform a "Phase Through Walls"
        /// </summary>
        public abstract void PerformSpecialAction();
    }
}
