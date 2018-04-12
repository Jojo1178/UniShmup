using UnityEngine;
using UnityEngine.UI;

public class MainGameUI : MonoBehaviour
{

    public Text scoreText;

    private void Update()
    {
        this.scoreText.text = "Score :  " + ApplicationController.Instance.mainGameController.GetPlayerScore().ToString();

        if (ApplicationController.Instance.applicationState == ApplicationState.GAME && Input.GetButton("Cancel"))
        {
            ApplicationController.Instance.ChangeApplicationState(ApplicationState.PAUSE);
        }
    }

    public void PauseButtonOnClick()
    {
        ApplicationController.Instance.ChangeApplicationState(ApplicationState.PAUSE);
    }
}
