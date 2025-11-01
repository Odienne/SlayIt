using System.Collections;
using UnityEngine;

public class HealSystem : Singleton<HealSystem>
{
    [SerializeField] private GameObject healVFX;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<HealGA>(HealPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<HealGA>();
    }

    private IEnumerator HealPerformer(HealGA healGA)
    {
        //Could just hard code the hero here but i prefer to add a new target mode
        foreach (var target in healGA.Targets)
        {
            target.Heal(healGA.Amount);
            Instantiate(healVFX, target.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
        }
    }
}