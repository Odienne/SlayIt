using Unity.VisualScripting;
using UnityEngine;

public class EndTurnButtonUI : MonoBehaviour
{
    public void OnButtonClick()
    {
        EnemyTurnGA enemyTurnGa = new();
        ActionSystem.Instance.Perform(enemyTurnGa);
    }
}
