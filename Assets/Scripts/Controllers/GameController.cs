using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private Button pauseButton; 
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button startButton;
    [SerializeField] private BrickManager brickManager;
   
    private bool _isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
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

    public void StartGame()
    {
        if (brickManager != null)
        {
            if (brickManager.AreBricksPresent()) // проверка наличия кирпичиков
            {
                GameManager.Instance.StartGame();
                brickManager.CheckForBricksContinuously();
            }
            else
            {
                StartCoroutine(ShowErrorPanelForDuration(2f)); 
            }
        }
    }
    
    private IEnumerator ShowErrorPanelForDuration(float duration)
    {
        UIManager.Instance.ShowErrorPanel();
        yield return new WaitForSeconds(duration); 
        UIManager.Instance.HideErrorPanel();
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
        SceneManager.LoadScene(0); 
    }
}