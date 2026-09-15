using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject gameplayUI;
    public GameObject pausedUI;
    private void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
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
}
