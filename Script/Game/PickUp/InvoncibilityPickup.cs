using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvoncibilityPickup : Pickup
{
    #region Public Var
    public float duration;
    #endregion
    #region Override Function
    protected override void OnPlayerCollect()
    {
        base.OnPlayerCollect();
        // Script Logic
        game.HandleInvincibilityPickup(duration);
    }
    #endregion
}
