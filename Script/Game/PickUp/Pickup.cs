using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    #region Public Var
    #endregion
    #region Private Var
    private GameController m_Game;
    private bool m_Didcollect;
    #endregion

    //Get GameController with integrity
    protected GameController game
    {
        get
        {
            if (!m_Game)
            {
                m_Game = GameController.instance;
            }
            if (!m_Game)
            {
                Debug.LogError("There is no Game Controller for Pickup!");
            }
            return m_Game;
        }
    }
    #region Unity Function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!game) return;
        if (m_Didcollect) return;
        if (collision.gameObject.tag.Equals("Player"))
        {
            m_Didcollect = true;
            OnPlayerCollect();
            Destroy(gameObject);
        }
    }
    #endregion
    #region Override Function
    protected virtual void OnPlayerCollect()
    {
        Debug.Log("Player Picked up [" + gameObject.name + "].");
    }
    #endregion
    #region Public Function

    #endregion
    #region Private Function

    #endregion
}
