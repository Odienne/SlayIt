using System.Collections.Generic;
using UnityEngine;

public class DealDamage : Effect
{
    [SerializeField] private int damageAmount;

    public override GameAction GetGameAction(List<CombatantView> targets, CombatantView caster)
    {
        DealDamageGA DealDamageGA = new(damageAmount, targets, caster);
        return DealDamageGA;
    }
}