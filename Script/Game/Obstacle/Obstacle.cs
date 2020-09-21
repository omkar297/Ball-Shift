using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerController player;
    #region Unity Function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameController.instance.OnPlayerHitObstacle();
            Time.timeScale = 0;
            //Debug.Log("Player is hited someone!");
        }
    }
    #endregion
}
