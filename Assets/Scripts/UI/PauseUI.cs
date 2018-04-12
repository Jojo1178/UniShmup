using UnityEngine;

public class PauseUI : MonoBehaviour {

    public void MainMenuButtonOnClick()
    {
        ApplicationController.Instance.ChangeApplicationState(ApplicationState.MAINMENU);
    }

    public void ResumeButtonOnClick()
    {
        ApplicationController.Instance.ChangeApplicationState(ApplicationState.GAME);
    }
}
