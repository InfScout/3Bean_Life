using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public enum GameState
{ 
Paused,
GameOver,
YouWin,
UnPaused
}
public class GameMan : MonoBehaviour
{
    public static GameMan Instance;
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject youWinScreen;
    [SerializeField] private GameObject pauseScreen;
    public bool gameIsPaused = false;
    
    
    private void Awake()
    {
        gameState = GameState.UnPaused;
        if (Instance == null)
            Instance = this;
    }
    private void Update()
    {
        switch (gameState)
        {
            case GameState.Paused:
                PauseGame();
                break;
            case GameState.UnPaused:
                UnPauseGame();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.YouWin:
                YouWin();
                break;
        }
    }
//pausing game

    public void PauseAction(InputAction.CallbackContext context)
    {
        if (gameState == GameState.Paused)
        {
            gameState = GameState.UnPaused;
        }
        else
        {
            gameState = GameState.Paused;
        }
    }
    public void UnPauseAction()
    {
        gameState = GameState.UnPaused;
    }
    private void PauseGame()
    {
        pauseScreen.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0;
    }
    
    private void UnPauseGame()
    {
        pauseScreen.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1;
    }
//You Win / lose
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void YouWin()
    {
        youWinScreen.SetActive(true);
    }
    
}
