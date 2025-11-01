using UnityEngine;

public class PlayCardGA : GameAction
{
    public Card Card { get; set; }
    public EnemyView ManualTarget { get; private set; }

    // no target card
    public PlayCardGA(Card card)
    {
        Card = card;
        ManualTarget = null;
    }
    
    //card with a target
    public PlayCardGA(Card card, EnemyView target)
    {
        Card = card;
        ManualTarget = target;
    }
}
