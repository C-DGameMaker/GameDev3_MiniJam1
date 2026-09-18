using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject gameplayUI;
    public GameObject pausedUI;
    public GameObject deathUI;
    private void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
        deathUI.SetActive(false);
    }

    public void ShowMainMenuUI()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }

    public void ShowGamePlayUI()
    {
        HideAllUI();
        gameplayUI.SetActive(true);
    }

    public void ShowPausedUI() 
    {
        HideAllUI();
        pausedUI.SetActive(true);
    }

    public void ShowDeathUI()
    {
        HideAllUI();
        deathUI.SetActive(true);
    }

}
