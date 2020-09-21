using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : Pickup
{
    #region Public Var
    public int multiplier;
    public float duration;
    #endregion
    #region Override Function
    protected override void OnPlayerCollect()
    {
        base.OnPlayerCollect();
        // Script Logic
        game.HandleScorePickup(multiplier,duration);
    }
    #endregion
}
