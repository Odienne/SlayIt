using System.Collections.Generic;
using UnityEngine;

public class HeroSystem : Singleton<HeroSystem>
{
    [field: SerializeField] public HeroView HeroView { get; private set; }
    
    //only one hero for now, but maybe create a board of heroes
    public List<HeroView> Heroes => new(){HeroView};

    void OnEnable()
    {
        ActionSystem.SubscribeReaction<EnemyTurnGA>(EnemyTurnPreReaction, ReactionTiming.PRE);
        ActionSystem.SubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    void OnDisable()
    {
        ActionSystem.UnsubscribeReaction<EnemyTurnGA>(EnemyTurnPreReaction, ReactionTiming.PRE);
        ActionSystem.UnsubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction, ReactionTiming.POST);
    }
    
    public void Setup(HeroData heroData)
    {
        HeroView.Setup(heroData);
    }
    
    // Reactions
    private void EnemyTurnPreReaction(EnemyTurnGA enemyTurnGa)
    {
        DiscardAllCardsGA discardAllCardsGa = new();
        ActionSystem.Instance.AddReaction(discardAllCardsGa);
        
        ResetManaGA resetManaGA = new(0);
        ActionSystem.Instance.AddReaction(resetManaGA);
    }

    private void EnemyTurnPostReaction(EnemyTurnGA enemyTurnGa)
    {
        int burnStacks = HeroView.GetStatusEffectStacks(StatusEffectType.BURN);
        if (burnStacks > 0)
        {
            ApplyBurnGA applyBurnGA = new(burnStacks, HeroView, null);
            ActionSystem.Instance.AddReaction(applyBurnGA);
        }

        DrawCardsGA drawCardsGa = new(5);
        ActionSystem.Instance.AddReaction(drawCardsGa);
    }
}
