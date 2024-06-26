﻿namespace Raiding.Models;

public class Paladin : BaseHero
{
    private const int power = 100;
    public Paladin(string name) : base(name, power)
    {
    }

    public override string CastAbility() => $"{GetType().Name} - {Name} healed for {Power}";
}
