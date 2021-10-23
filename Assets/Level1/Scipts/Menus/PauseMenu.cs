
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
       
    }

    public void Resume()
    {
        GameIsPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameManager.Instance.UpdateGameState(GameState.MenuInicial);
    }

    public void onSettings()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("SE VA A CERRAR ESTA BELLESAH");
        Application.Quit();
    }

    


}
