using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PerksUI : MonoBehaviour
{
    //this is the only script creating perks so no need for a PerkUICreator
    [SerializeField] private PerkUI PerkUIPrefab;
    private readonly List<PerkUI> perkUIs = new();

    public void AddPerkUI(Perk perk)
    {
        PerkUI perkUI = Instantiate(PerkUIPrefab, transform);
        perkUI.Setup(perk);
        perkUIs.Add(perkUI);
    }

    public void RemovePerkUI(Perk perk)
    {
        PerkUI perkUI = perkUIs.Where(pui => pui.Perk == perk).FirstOrDefault();
        if (perkUI != null)
        {
            perkUIs.Remove(perkUI);
            Destroy(perkUI.gameObject);
        }
    }
}
