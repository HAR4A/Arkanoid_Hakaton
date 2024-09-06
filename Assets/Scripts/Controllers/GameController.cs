using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance { get; private set; }

    [SerializeField] private Button pauseButton; 
    [SerializeField] private Button resumeButton;

    private bool _isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Метод для паузы игры
    public void TogglePause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;  
        BallController.Instance.rigidbody.simulated = false; 
        PaddleController.Instance.enabled = false;  
        
        pauseButton.gameObject.SetActive(false);  
        resumeButton.gameObject.SetActive(true);  
    }

    
    public void ResumeGame()
    {
        Time.timeScale = 1f;  
        BallController.Instance.rigidbody.simulated = true;  
        PaddleController.Instance.enabled = true; 
        
        pauseButton.gameObject.SetActive(true);   
        resumeButton.gameObject.SetActive(false); 
    }

    
    public void RestartGame() 
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
    
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(2); 
    }
}