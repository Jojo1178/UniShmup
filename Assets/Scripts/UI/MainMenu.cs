using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text gameTitle;

    private void Awake()
    {
        this.gameTitle.text = Application.productName;
    }

    public void NewGameButtonOnClick()
    {
        ApplicationController.INSTANCE.SwitchApplicationState(ApplicationState.GAME);
    }

    public void ExitButtonOnClick()
    {
        ApplicationController.INSTANCE.QuitApplication();
    }

}
