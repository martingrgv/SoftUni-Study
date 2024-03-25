namespace _01.FakeAxeAndDummy;

public interface ITarget
{
    int Health { get; }
    void TakeAttack(int attackPoints);
     int GiveExperience();
     bool IsDead();
}