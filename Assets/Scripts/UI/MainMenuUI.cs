using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    public Text gameTitle;

    private void Awake()
    {
        this.gameTitle.text = Application.productName;
    }

    public void NewGameButtonOnClick()
    {
        ApplicationController.Instance.ChangeApplicationState(ApplicationState.GAME);
    }

    public void ExitButtonOnClick()
    {
        ApplicationController.Instance.QuitApplication();
    }

}
