using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

    public Text finalScoreText;

    private void OnEnable()
    {
        this.finalScoreText.text = "Your final score is :\n" + ApplicationController.Instance.mainGameController.GetPlayerScore().ToString();
    }

    public void MainMenuButtonOnClick()
    {
        ApplicationController.Instance.ChangeApplicationState(ApplicationState.MAINMENU);
    }

    public void ExitButtonOnClick()
    {
        ApplicationController.Instance.QuitApplication();
    }
}
