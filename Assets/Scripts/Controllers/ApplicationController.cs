using UnityEngine;

/*
 * Application's main controller
 * Accessible from any script
 */
public class ApplicationController : MonoBehaviour {

    /* Singleton */
    private static ApplicationController _instance;
    public static ApplicationController Instance { get { return _instance; } }

    public ApplicationState applicationState; // Current application state

    /* Reference to other managers */
    public UIController uiController;
    public MainGameController mainGameController;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        this.ChangeApplicationState(ApplicationState.MAINMENU);
    }

    // Apply next application state to other controllers
    public void ChangeApplicationState(ApplicationState nextState)
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
    MAINMENU, // Application's first menu
    GAME, // Main state : Instantiates player, power-ups and enemies
    GAMEOVER, // Stops game update and destroy every enemies and bullets left on screen
    PAUSE // Stops game update to be resume later
}