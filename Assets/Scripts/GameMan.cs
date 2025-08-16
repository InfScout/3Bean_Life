using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public enum GameState
{ 
Paused,
YouWin,
UnPaused
}
public class GameMan : MonoBehaviour
{
    public static GameMan Instance;
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject youWinScreen;
    [SerializeField] private GameObject pauseScreen;
    public bool gameIsPaused = false;
    
    
    public int _score = 0;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    
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
            case GameState.YouWin:
                YouWin();
                break;
        }
    }


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

    public void YouWin()
    {
        youWinScreen.SetActive(true);
    }
    
    public void AddScore(int scoreAdd)
    {
        _score += scoreAdd;
    }
    
    public void UpdateScore()
    {
        
        _scoreText.text = "Score : " + _score;
    }
}
