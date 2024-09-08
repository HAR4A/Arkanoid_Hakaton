using UnityEngine;

public class ClassicGameManager : MonoBehaviour
{
    public static ClassicGameManager Instance { get; private set; }
    public static int savedLevelIndex = 0; 
    
    [SerializeField] private LevelData[] levels; 
    [SerializeField] private Transform brickParent;
    
    private int currentLevelIndex = 0;

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
        
        currentLevelIndex = savedLevelIndex;
    }
    
    public void HandleWinCondition()
    {
        BallController.Instance.LockBall();
        PaddleController.Instance.LockPaddle();
        
        ClassicUIManager.Instance.ShowWinPanel();
    }

    public int GetCurrentLevelIndex()
    {
        return currentLevelIndex;
    }

    public void Start()
    {
        LoadLevel(currentLevelIndex);
        BrickManager.Instance.CheckForBricksContinuously();
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex < levels.Length)
        {
            // сохранение нового уровня только на время сессии
            savedLevelIndex = currentLevelIndex;
            LoadLevel(currentLevelIndex);
        }
        else
        {
            Debug.Log("Все уровни пройдены!");
        }
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levels.Length)
        {
            ClearBricks();

            LevelData levelData = levels[levelIndex];

            foreach (var position in levelData.brickPositions)
            {
                Instantiate(levelData.brickPrefab, position, Quaternion.identity, brickParent);
            }

            ClassicUIManager.Instance.UpdateLevelText(levelData.levelNumber);
        }
    }

    public void ClearBricks()
    {
        BrickController[] bricks = FindObjectsOfType<BrickController>();
        foreach (var brick in bricks)
        {
            Destroy(brick.gameObject);
        }
    }
}
