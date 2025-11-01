using System;
using System.Collections;
using UnityEngine;

public class DamageSystem : Singleton<DamageSystem>
{
    [SerializeField] private GameObject damageVFX;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<DealDamageGA>(DealDamagePerformer);
    }
    
    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DealDamageGA>();
    }

    private IEnumerator DealDamagePerformer(DealDamageGA dealDamageGA)
    {
        foreach (var target in dealDamageGA.Targets)
        {
            if (target != null)
            {
                target.Damage(dealDamageGA.Amount);
                //could extend to pass the type of damage and change the VFX ? 
                Instantiate(damageVFX, target.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                
                if (target.CurrentHealth <= 0)
                {
                    if (target is EnemyView enemyView)
                    {
                        KillEnemyGA killEnemyGA = new(enemyView);
                        ActionSystem.Instance.AddReaction(killEnemyGA);
                    }
                    else
                    {
                        // do some other logic maybe like
                        // game over scene or restart scene
                    }
                }
            }
        }
    }
}
