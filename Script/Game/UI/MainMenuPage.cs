using System.Collections;
using System.Collections.Generic;
using UnityCore.Audio;
using UnityCore.Menu;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPage : Page
{
    public PageController pages;
    #region Public Function
    public void StartGame()
    {
        //Game is Play
        GameController.instance.TryAgain();
        //Close this game Start page!!
        pages.TurnPageOff(type);
    }
    public void exit()
    {
        this.exit();
    }
    #endregion 
    #region Override Function
    protected override void OnPageEnabled()
    {
        base.OnPageEnabled();
        AudioController.instance.PlayAudio(UnityCore.Audio.AudioType.ST_01, true, 1);
    }
    #endregion
}
