using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Session;
using UnityEngine.UI;
using System.Dynamic;
using UnityCore.Menu;

public class GameController : MonoBehaviour
{
    #region Public Var
    public PageController pages;
    public static GameController instance;
    public PlayerController Player;
    public CameraController Camera;
    public int pickupDropRate = 3;
    public ObstacleController obstacles;
    public Text ScoreText;
    public bool m_GameOver;
    public int Score { get; private set; }
    #endregion
    #region private var
    private SessionController m_Session;
    private int m_progress = -1;

    private int m_ScoreMultiplier = 1;
    private bool m_DidDropPickup;
    private bool m_Invicible;
    private float m_ScoreMultiplierDuration;
    private float m_InvicibilityDuration;
    #endregion
    //get session with integrity
    private SessionController session
    {
        get
        {
            if (!m_Session)
            {
                m_Session = SessionController.instance;
            }
            if (!m_Session)
            {
                Debug.LogWarning("Game is trying to access the session, but there is no instance of SessionController");
                return null;
            }
            return m_Session;
        }
    }
    #region Unity Function
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        Time.timeScale = 0;
    }
    private void Start()
    {
        if (!session) return;
        session.InitializeGame(this);
    }

    #endregion
    #region Public Function
    public void OnUpdate()
    {
        //Update all of game system
        Player.OnUpdate();
        Camera.OnUpdate();
        CheckPlayerProgress();
        DetectPlayerFall();
    }
    public void OnInit()
    {
        //Initialize all of game system

        Player.OnInit();
        Camera.OnInit();
        obstacles.AddOnstacles(m_progress);
    }
    public void HandleInvincibilityPickup(float _duration)
    {
        m_InvicibilityDuration = _duration;
        m_Invicible = true;
        // Cancel The Score pickup
        m_ScoreMultiplier = 1;
        m_ScoreMultiplierDuration = 0;
    }
    public void HandleScorePickup(int _multiplier,float _duration)
    {
        m_ScoreMultiplier = _multiplier;
        m_ScoreMultiplierDuration = _duration;
        // Cancel The Score pickup
        m_Invicible = false;
        m_InvicibilityDuration = 0;
    }
    public void OnPlayerHitObstacle()
    {
        if (m_Invicible) return;
        EndGame();
    }
    public void TryAgain()
    {
        Time.timeScale = 1;
        Reset();
    }
    #endregion
    #region Private Function
    private void CheckPlayerProgress()
    {
        if (Player.transform.position.y / obstacles.interval > (m_progress + 1))
        {
            m_progress++;
            Score += m_ScoreMultiplier;
            ScoreText.text = Score.ToString();
            obstacles.AddOnstacles(m_progress);
        }
        if(m_progress>0 && m_progress % pickupDropRate == 0)
        {
            if (!m_DidDropPickup)
            {
                m_DidDropPickup = true;
                obstacles.AddPickup(m_progress);
            }
            else
            {
                m_DidDropPickup = false;
            }
        }
    }
    private void EnforcePickupRules()
    {
        float _dt = Time.deltaTime;
        m_InvicibilityDuration -= _dt;
        m_ScoreMultiplierDuration -= _dt;
        if(m_ScoreMultiplierDuration<=0 && m_ScoreMultiplier != 1)
        {
            m_ScoreMultiplier = 1;
        }
        if (m_InvicibilityDuration <= 0 && m_Invicible)
        {
            m_Invicible = false;
            m_InvicibilityDuration = 0;
        }
    }
    private void DetectPlayerFall()
    {
        if (Camera.transform.position.y - Player.transform.position.y > 5)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        if (m_GameOver) return;
        m_GameOver = true;
        //Pause the Player, Play Animation if have, show game over panel
        pages.TurnPageOn(PageType.GameOver);
    }
    private void Reset()
    {
        //Reset progress
        m_progress = -1;
        obstacles.AddOnstacles(m_progress);
        //Reset all to zero
        Score = 0;
        ScoreText.text = Score.ToString();
        obstacles.Reset();
        Player.Reset();
        Camera.Reset();
        m_GameOver = false;
        //Debug.Log("Player Game_Reset is Succeccfuly!!");
    }
    #endregion
}
