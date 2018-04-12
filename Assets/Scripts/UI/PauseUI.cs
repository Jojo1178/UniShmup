using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour {

    public void MainMenuButtonOnClick()
    {
        ApplicationController.INSTANCE.SwitchApplicationState(ApplicationState.MAINMENU);
    }

    public void ResumeButtonOnClick()
    {
        ApplicationController.INSTANCE.SwitchApplicationState(ApplicationState.GAME);
    }
}
