using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Application Main controller
 * Accessible from any script
 */
public class ApplicationController : MonoBehaviour {

    public static ApplicationController INSTANCE; // Singleton 

    public ApplicationState applicationState; // Current application state

    /* Reference to other managers */
    public UIController uiController;
    public MainGameController mainGameController;


    private void Awake()
    {
        INSTANCE = this;
        this.SwitchApplicationState(ApplicationState.MAINMENU);
    }

    public void SwitchApplicationState(ApplicationState nextState)
    {
        if (this.applicationState != nextState)
        {
            this.uiController.SetUI(nextState);
            this.mainGameController.SetGameScene(this.applicationState, nextState);
            this.applicationState = nextState;
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
    
}

public enum ApplicationState
{
    INIT,
    MAINMENU,
    GAMEOVER,
    GAME
}