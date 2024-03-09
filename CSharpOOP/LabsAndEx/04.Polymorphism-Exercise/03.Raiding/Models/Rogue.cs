﻿namespace Raiding.Models;

public class Rogue : BaseHero
{
    private const int power = 80;

    public Rogue(string name) : base(name, power)
    {
    }

    public override string CastAbility() => $"{GetType().Name} - {Name} hit for {Power} damage";
}
