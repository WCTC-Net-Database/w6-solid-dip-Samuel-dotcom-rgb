namespace W06.Interfaces
{
    public interface ICharacter
    {
        void Attack(ICharacter target);
        void Move();
        string Name { get; set; }
    }

}
