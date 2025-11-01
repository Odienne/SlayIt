using System;
using UnityEngine;

public class OnEnemyAttackedCondition : PerkCondition
{
    public override bool SubConditionIsMet(GameAction reaction)
    {
        return true;
    }
    
    public override void SubscribeCondition(Action<GameAction> reaction)
    {
        ActionSystem.SubscribeReaction<AttackHeroGA>(reaction, reactionTiming);
    }

    public override void UnsubscribeCondition(Action<GameAction> reaction)
    {
        ActionSystem.UnsubscribeReaction<AttackHeroGA>(reaction, reactionTiming);
    }
}
