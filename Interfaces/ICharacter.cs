namespace W06.Interfaces
{
public interface ICharacter
{
    string Name { get; set; }
    int HitPoints { get; set; }
    int Level { get; set; }

    void Attack(ICharacter target);
    void PerformSpecialAction();
    bool IsAlive();
}
