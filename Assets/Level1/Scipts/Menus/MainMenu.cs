
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MainMenu : MonoBehaviour
{

    public GameObject ContinueUI;
    //public GameObject MainMenuUI;

   /* private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;

    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState obj)
    {
        gameObject.SetActive(obj == GameState.MenuInicial);
    }*/

    private void Start()
    {
        //uso de menu CON o SIN "CONTINUAR" en funcion si hay archivo para cargar partida nueva
        string pathFileHeart = Application.persistentDataPath + "/heart.fun";
        string pathFilePlayer = Application.persistentDataPath + "/player.fun";
        if (File.Exists(pathFilePlayer) && File.Exists(pathFileHeart))
        {
            this.gameObject.SetActive(false);
            ContinueUI.SetActive(true);
        }else
        {
            ContinueUI.SetActive(false);
        }
    }
    public void PlayGame()
    {
        GameManager.Instance.UpdateGameState(GameState.NewGame);
        
    }


    public void QuitGame()
    {
        Debug.Log("SE CIERRA LA APP");
        Application.Quit();
    }

    public void Continue()
    {
        GameManager.Instance.UpdateGameState(GameState.ContinueGame);
        
          
        
    }





    
}
