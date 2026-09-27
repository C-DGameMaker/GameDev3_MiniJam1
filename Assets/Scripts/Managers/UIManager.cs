using UnityEngine;
/// <summary>
/// Charlie Dobson
/// 
/// Manages all the UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject gameplayUI;
    public GameObject pausedUI;
    public GameObject deathUI;
    public GameObject InstructionUI;
    public GameObject creditsUI;
    private void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
        deathUI.SetActive(false);
        InstructionUI.SetActive(false);
        creditsUI.SetActive(false);
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

    public void ToggleInstruction()
    {
        bool currentState = InstructionUI.activeSelf;
        currentState = !currentState;
        InstructionUI.SetActive(currentState);
    }

    public void ToggleCredits()
    {
        bool currentState = creditsUI.activeSelf;
        currentState = !currentState;
        creditsUI.SetActive(currentState);
    }

}
