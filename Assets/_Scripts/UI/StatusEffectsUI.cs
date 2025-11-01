using System;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectsUI : MonoBehaviour
{
    [SerializeField] private StatusEffectUI statusEffectUIPrefab;
    [SerializeField] private Sprite armorSprite, burnSprite;

    private Dictionary<StatusEffectType, StatusEffectUI> statusEffectUis = new();

    public void UpdateStatusEffectUI(StatusEffectType statusEffectType, int stackCount)
    {
        if (stackCount == 0)
        {
            if (statusEffectUis.ContainsKey(statusEffectType))
            {
                StatusEffectUI statusEffectUI = statusEffectUis[statusEffectType];
                statusEffectUis.Remove(statusEffectType);
                Destroy(statusEffectUI.gameObject);
            }   
        }
        else
        {
            if (!statusEffectUis.ContainsKey(statusEffectType))
            {
                StatusEffectUI statusEffectUI = Instantiate(statusEffectUIPrefab, transform);
                statusEffectUis.Add(statusEffectType, statusEffectUI);
            }

            Sprite sprite = GetSpriteByType(statusEffectType);
            statusEffectUis[statusEffectType].Set(sprite, stackCount);
        }
    }

    private Sprite GetSpriteByType(StatusEffectType statusEffectType)
    {
        return statusEffectType switch
        {
            StatusEffectType.ARMOR => armorSprite,
            StatusEffectType.BURN => burnSprite,
            _ => null
        };
    }
}
