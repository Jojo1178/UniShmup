using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUI : MonoBehaviour
{

    public Text scoreText;

    private void Update()
    {
        this.scoreText.text = "Score :  " + ApplicationController.INSTANCE.mainGameController.GetPlayerScore().ToString();

        if (ApplicationController.INSTANCE.applicationState == ApplicationState.GAME && Input.GetButton("Cancel"))
        {
            ApplicationController.INSTANCE.SwitchApplicationState(ApplicationState.PAUSE);
        }
    }

    public void PauseButtonOnClick()
    {
        ApplicationController.INSTANCE.SwitchApplicationState(ApplicationState.PAUSE);
    }
}
