using UnityEngine;

public class ResetManaGA : GameAction
{
    public int ResetValue { get; set; }

    public ResetManaGA(int resetValue)
    {
        ResetValue = resetValue;
    }
}
