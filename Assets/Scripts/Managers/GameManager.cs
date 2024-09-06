using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool _isEditMode = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        _isEditMode = false;
        UIManager.Instance.ToggleUIForGameplay();
        BallController.Instance.UnlockBall();
        PaddleController.Instance.UnlockPaddle();
    }

    public bool IsEditMode() => _isEditMode;
}