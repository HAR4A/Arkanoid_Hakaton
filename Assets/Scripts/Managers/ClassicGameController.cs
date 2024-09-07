using UnityEngine;

public class ClassicGameController : MonoBehaviour
{
    public static ClassicGameController Instance { get; private set; }
    
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

    // вызывается, когда кирпичи на уровне уничтожены
    public void HandleLevelCompleted()
    {
        ClassicUIManager.Instance.ShowWinPanel();
    }

    
    public void HandleGameOver()
    {
        ClassicUIManager.Instance.ShowLosePanel();
    }

    // переход на следующий уровень
    public void OnNextLevelButtonClicked()
    {
        ClassicUIManager.Instance.HideWinPanel();
        ClassicGameManager.Instance.LoadNextLevel();
    }
}