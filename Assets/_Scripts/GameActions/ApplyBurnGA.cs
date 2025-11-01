using System.Collections.Generic;
using UnityEngine;

public class ApplyBurnGA : GameAction
{
    //this GA only applies the burn damage
    public int BurnDamage { get; set; }
    public CombatantView Target { get; private set; } 
    public CombatantView Caster { get; private set; } 

    public ApplyBurnGA(int burnDamage, CombatantView target, CombatantView caster)
    {
        BurnDamage = burnDamage;
        Target = target;
        Caster = caster;
    }
}