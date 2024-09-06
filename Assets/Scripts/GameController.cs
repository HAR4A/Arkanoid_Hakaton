using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance { get; private set; }

    [SerializeField] private Button pauseButton; // Кнопка паузы
    [SerializeField] private Button resumeButton; // Кнопка возобновления игры

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

    // Метод для полной остановки мяча и ракетки
    private void PauseGame()
    {
        Time.timeScale = 0f;  // Останавливаем время в игре
        BallController.Instance.rigidbody.simulated = false;  // Отключаем физику мяча
        PaddleController.Instance.enabled = false;  // Отключаем управление ракеткой
        
        pauseButton.gameObject.SetActive(false);  // Скрываем кнопку паузы
        resumeButton.gameObject.SetActive(true);  // Показываем кнопку возобновления
    }

    // Метод для возобновления игры
    public void ResumeGame()
    {
        Time.timeScale = 1f;  // Возвращаем нормальную скорость игры
        BallController.Instance.rigidbody.simulated = true;  // Включаем физику мяча
        PaddleController.Instance.enabled = true;  // Включаем управление ракеткой
        
        pauseButton.gameObject.SetActive(true);   // Показываем кнопку паузы
        resumeButton.gameObject.SetActive(false);  // Скрываем кнопку возобновления
    }

    // Метод для перезапуска текущей сцены
    public void RestartGame()
    {
        Time.timeScale = 1f;  // На всякий случай сбрасываем скорость игры на нормальную
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Перезагружаем текущую сцену
    }
}