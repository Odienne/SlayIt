using System;
using System.Collections;
using UnityEngine;

public class ManaSystem : Singleton<ManaSystem>
{
    [SerializeField] private ManaUI manaUI;

    private int currentPlayerTurn = 0;
    private const int MIN_MANA = 0;
    private const int START_MANA = 3;
    private const int MAX_MANA = 12;

    private int currentMana = START_MANA;

    private void OnEnable()
    {
        manaUI.UpdateManatext(currentMana);

        ActionSystem.AttachPerformer<SpendManaGA>(SpendManaPerformer);
        ActionSystem.AttachPerformer<RefillManaGA>(RefillManaPerformer);
        ActionSystem.AttachPerformer<ResetManaGA>(ResetManaPerformer);
        ActionSystem.SubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<SpendManaGA>();
        ActionSystem.DetachPerformer<RefillManaGA>();
        ActionSystem.DetachPerformer<ResetManaGA>();
        ActionSystem.UnsubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    public bool HasEnoughMana(int mana)
    {
        return currentMana >= mana;
    }

    private IEnumerator SpendManaPerformer(SpendManaGA spendManaGA)
    {
        currentMana = currentMana - spendManaGA.Amount < MIN_MANA ? 0 : currentMana - spendManaGA.Amount;
        manaUI.UpdateManatext(currentMana);
        yield return null;
    }

    private IEnumerator RefillManaPerformer(RefillManaGA refillManaGA)
    {
        currentMana = currentMana + refillManaGA.Amount > MAX_MANA ? MAX_MANA : currentMana + refillManaGA.Amount;
        manaUI.UpdateManatext(currentMana);
        yield return null;
    }
    
    private IEnumerator ResetManaPerformer(ResetManaGA resetManaGA)
    {
        currentMana = resetManaGA.ResetValue;
        manaUI.UpdateManatext(currentMana);
        yield return null;
    }

    private void EnemyTurnPostReaction(EnemyTurnGA enemyTurnGA)
    {
        currentPlayerTurn += 1;
        RefillManaGA refillManaGA = new(START_MANA + currentPlayerTurn);
        ActionSystem.Instance.AddReaction(refillManaGA);
    }
}