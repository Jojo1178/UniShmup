using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

    public Text finalScoreText;

    private void OnEnable()
    {
        this.finalScoreText.text = "Your final score is :\n" + ApplicationController.INSTANCE.mainGameController.GetPlayerScore().ToString();
    }

    public void MainMenuButtonOnClick()
    {
        ApplicationController.INSTANCE.SwitchApplicationState(ApplicationState.MAINMENU);
    }

    public void ExitButtonOnClick()
    {
        ApplicationController.INSTANCE.QuitApplication();
    }
}
