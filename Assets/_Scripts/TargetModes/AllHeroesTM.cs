using System.Collections.Generic;
using UnityEngine;

public class AllHeroesTM : TargetMode
{
    public override List<CombatantView> GetTargets()
    {
        return new(HeroSystem.Instance.Heroes);
    }
}
