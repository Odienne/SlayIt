using System;
using TMPro;
using UnityEngine;

public class ManaUI : MonoBehaviour
{
    [SerializeField] private TMP_Text mana;

    public void UpdateManatext(int currentMana)
    {
        mana.text = currentMana.ToString();
    }
}
