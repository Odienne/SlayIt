using System.Collections.Generic;
using UnityEngine;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private HeroData heroData;
    [SerializeField] private List<EnemyData> enemyDatas;
    [SerializeField] private PerkData perkData;

    private void Start()
    {
        HeroSystem.Instance.Setup(heroData);
        CardSystem.Instance.Setup(heroData.Deck);
        EnemySystem.Instance.Setup(enemyDatas);
        PerkSystem.Instance.AddPerk(new Perk(perkData));

        DrawCardsGA drawCardsGa = new(5);
        ActionSystem.Instance.Perform(drawCardsGa);
    }
}
