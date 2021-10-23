using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if(GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        //SceneManager.GetActiveScene().name.ToString();
       // Debug.Log(SceneManager.GetActiveScene().name.ToString());
        UpdateGameState(GameState.MenuInicial);
    }
    public void UpdateGameState(GameState newGameState)
    {
        State = newGameState;
        Debug.Log(State.ToString());
        switch (newGameState)
        {
            case GameState.NewGame:
                    newGameFunction();
                break;
            case GameState.ContinueGame:
                    continueGameFunction();
                break;
            case GameState.MenuInicial:
                    mainMenuFunction();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newGameState), newGameState, null);
        }
        OnGameStateChanged?.Invoke(newGameState);

    }


    void newGameFunction()
    {

        CorazonVida.listaCorazones.Clear();
        SceneManager.LoadScene("Game");
    }
    void mainMenuFunction()
    {
        SceneManager.LoadScene("Menu");
    }
    void continueGameFunction()
    {
        CorazonVida.listaCorazones.Clear();
        
        SceneManager.LoadScene("Game");
    }

}


public enum GameState
    {
        MenuInicial,
        NewGame,
        ContinueGame
    }
