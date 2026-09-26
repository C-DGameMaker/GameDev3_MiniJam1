using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Charlie Dobson
/// 
/// Manages all the button scripts
/// </summary>
public class ButtonManager : MonoBehaviour
{
    // Just the service hub manager
    public ServiceHubManager serviceHub;

    private void Start()
    {
        // Gets the service hub manager if it is empty
        if(serviceHub == null)
        {
            serviceHub = GetComponent<ServiceHubManager>();
        }
        
    }

    // Stars the game by changing the state to gameplay
    public void StartGameButton()
    {
        serviceHub.gameStateManager.SetState(newState: GameStates.Gameplay);
    }

    // closes the program
    public void QuitButton()
    {
        Application.Quit();
    }

    // Makes it so when you hit the keyboard binding for pausing, will pause and unpause the game
    public void PauseToggle()
    {
        if (serviceHub.gameStateManager._currentState == GameStates.Gameplay)
        {
            if (serviceHub.gameStateManager._currentState == GameStates.Paused) return;
            serviceHub.gameStateManager.SetState(newState: GameStates.Paused);

        }
        else if(serviceHub.gameStateManager._currentState == GameStates.Paused)
        {
            if (serviceHub.gameStateManager._currentState == GameStates.Gameplay) return;
            serviceHub.gameStateManager.SetState(newState: GameStates.Gameplay);
        }
    }

    // When you hit the back to gameplay button, will take you back to the gameplay
    public void BackToGameButton()
    {
        serviceHub.gameStateManager.SetState
            (newState: serviceHub.gameStateManager._previousState);

        if(serviceHub.gameStateManager._currentState 
            == GameStates.Paused)
        {
            serviceHub.gameStateManager._previousState = GameStates.Gameplay;
        }
    }

    // From death, resets the game and takes you back to the menu
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        serviceHub.gameStateManager.SetState
            (newState: GameStates.init);
    }

    // Just a test button to make sure death works
    public void DeathButton()
    {
        if (serviceHub.gameStateManager._currentState != GameStates.Gameplay) return;

        serviceHub.gameStateManager.SetState(newState: GameStates.Death);
    }
}
