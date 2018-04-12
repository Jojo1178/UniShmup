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

    // Apply next ApplicationState to other controllers
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
    INIT, //Application start-up
    MAINMENU, // Application first menu
    GAME, // Main state : Spawn player, enemies
    GAMEOVER, // Stop game update and destroy every enemies and bullets left on screen
    PAUSE // Stop game update to be resume later
}