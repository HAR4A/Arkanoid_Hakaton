using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClassicGameController : MonoBehaviour
{
    public static ClassicGameController Instance { get; private set; }

    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button nextLevelButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    public void HandleLevelCompleted()
    {
        ClassicUIManager.Instance.ShowWinPanel();
    }

    public void HandleGameOver()
    {
        ClassicUIManager.Instance.ShowLosePanel();
    }

    
    public void OnNextLevelButtonClicked()
    {
        BallController.Instance.UnlockBall();
        PaddleController.Instance.UnlockPaddle();

        ClassicUIManager.Instance.HideWinPanel();
        ClassicGameManager.Instance.LoadNextLevel();
    }

    public void PauseGame()
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
        ClassicGameManager.Instance.SaveLevelIndex(ClassicGameManager.Instance.GetCurrentLevelIndex());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
}
