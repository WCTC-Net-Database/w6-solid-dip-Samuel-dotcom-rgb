using W06.Data;
using W06.Models;

namespace W06.Services
{
    /// <summary>
    /// GameEngine demonstrates Dependency Inversion Principle (DIP).
    ///
    /// Notice:
    /// 1. We depend on IContext (abstraction), not DataContext (concrete)
    /// 2. We can work with CharacterBase without knowing the specific type
    /// 3. PerformSpecialAction() works on ANY character - that's polymorphism!
    /// </summary>
    public class GameEngine
    {
        private readonly IContext _context;
        private readonly Player _player;
        private readonly Goblin _goblin;

        // DIP: We receive our dependency through the constructor (injection)
        // We don't create it ourselves - that would be a tight coupling!
        public GameEngine(IContext context)
        {
            _context = context;
            _player = context.Characters.OfType<Player>().FirstOrDefault();
            _goblin = _context.Characters.OfType<Goblin>().FirstOrDefault();
        }

        public void Run()
        {
            if (_player == null || _goblin == null)
            {
                Console.WriteLine("Failed to initialize game characters.");
                return;
            }

            Console.WriteLine($"Player Gold: {_player.Gold}");

            // Combat sequence
            _goblin.Move();
            _goblin.Attack(_player);

            _player.Move();
            _player.Attack(_goblin);

            Console.WriteLine($"Player Gold: {_player.Gold}");

            // ==========================================
            // DEMONSTRATING ABSTRACT METHODS (DIP)
            // ==========================================
            // Each character type has their own PerformSpecialAction!
            // We call the SAME method name, but get DIFFERENT behavior.
            // This is polymorphism - a key OOP concept!

            Console.WriteLine("\n=== Special Actions ===");
            _player.PerformSpecialAction();  // "performs a powerful sword strike!"
            _goblin.PerformSpecialAction();  // "performs a sneaky backstab!"

            // We can also loop through ALL characters and call PerformSpecialAction
            // This works because they all inherit from CharacterBase!
            Console.WriteLine("\n=== All Characters' Special Actions ===");
            foreach (CharacterBase character in _context.Characters)
            {
                character.PerformSpecialAction();
            }
        }
    }
}
