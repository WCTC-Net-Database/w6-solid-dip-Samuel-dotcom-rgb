using W06.Interfaces;

namespace W06.Models
{
public abstract class CharacterBase : ICharacter
{
    // ── Shared Properties ─────────────────────────────────────────────────────
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int Level { get; set; }

    // ── Constructor ───────────────────────────────────────────────────────────
    protected CharacterBase(string name, int hitPoints, int level)
    {
        Name = name;
        HitPoints = hitPoints;
        Level = level;
    }

    // ── Shared / Virtual Methods ──────────────────────────────────────────────

    /// <summary>
    /// Basic attack shared by all characters. Derived classes can override if needed.
    /// </summary>
    public virtual void Attack(ICharacter target)
    {
        int damage = Level * 5;
        target.HitPoints -= damage;
        Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage! " +
                          $"({target.Name} has {target.HitPoints} HP remaining)");
    }

    /// <summary>Returns true if this character still has HP.</summary>
    public bool IsAlive() => HitPoints > 0;

    // ── Abstract Methods ──────────────────────────────────────────────────────

    /// <summary>
    /// Every character type has a unique special action.
    /// Derived classes MUST override this method.
    /// </summary>
    public abstract void PerformSpecialAction();

    // ── Helper ────────────────────────────────────────────────────────────────
    public override string ToString() =>
        $"[{GetType().Name}] {Name} | HP: {HitPoints} | Level: {Level}";
}
