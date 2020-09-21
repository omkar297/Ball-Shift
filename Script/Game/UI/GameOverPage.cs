using System.Collections;
using System.Collections.Generic;
using UnityCore.Menu;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPage : Page
{
    public PageController pages;
    public Text ScoreText;
    #region Public Function
    public void TryAgain()
    {
        //Game is reset
        GameController.instance.TryAgain();
        //Close this game over page!!
        pages.TurnPageOff(type);
        Time.timeScale = 1;
    }
    public void GoToHome()
    {
        //Turn off game over page
        pages.TurnPageOff(type);
        //Turn on Main menu page
        pages.TurnPageOn(PageType.Menu);
        Time.timeScale = 1;
    }
    public void exit()
    {
        Application.Quit();
    }
    #endregion 
    #region Override Function
    protected override void OnPageEnabled()
    {
        base.OnPageEnabled();
        //Capture the player score and display it!!
        //Debug.Log(GameController.instance.Score.ToString());
        ScoreText.text = "" + GameController.instance.Score.ToString();
    }
    #endregion
}
