using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handle menu display
 */
public class UIController : MonoBehaviour {

    public MainMenu mainMenu;
    public GameOverMenu gameOverMenu;
    
    public void SetUI(ApplicationState nextState)
    {
        this.mainMenu.gameObject.SetActive(nextState == ApplicationState.MAINMENU);
        this.gameOverMenu.gameObject.SetActive(nextState == ApplicationState.GAMEOVER);
    }
}
