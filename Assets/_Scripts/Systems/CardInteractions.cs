using UnityEngine;

public class CardInteractions : Singleton<CardInteractions>
{
    public bool PlayerIsDragging { get; set; } = false;

    public bool CanPlayerInteract()
    {
        if (!ActionSystem.Instance.IsPerforming) return true;
        return false;
    }

    public bool CanPlayerHover()
    {
        if (PlayerIsDragging) return false;
        return true;
    }
}
