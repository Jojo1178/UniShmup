using UnityEngine;

/*
 * Manages menu display
 */
public class UIController : MonoBehaviour {

    public MainMenuUI mainMenuUI;
    public GameOverUI gameOverUI;
    public MainGameUI mainGameUI;
    public PauseUI pauseUI;

    //Displays the UI depending on next application state
    public void SetUI(ApplicationState nextState)
    {
        this.mainMenuUI.gameObject.SetActive(nextState == ApplicationState.MAINMENU);
        this.gameOverUI.gameObject.SetActive(nextState == ApplicationState.GAMEOVER);
        this.mainGameUI.gameObject.SetActive(nextState == ApplicationState.GAME || nextState == ApplicationState.PAUSE);
        this.pauseUI.gameObject.SetActive(nextState == ApplicationState.PAUSE);
    }
}
