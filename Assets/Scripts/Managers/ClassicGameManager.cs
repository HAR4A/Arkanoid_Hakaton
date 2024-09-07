using System.IO;
using UnityEngine;

public class ClassicGameManager : MonoBehaviour
{
    public static ClassicGameManager Instance { get; private set; }
    public static int savedLevelIndex = 0; 
    
    [SerializeField] private LevelData[] levels; 
    [SerializeField] private Transform brickParent;
    
    private int currentLevelIndex = 0;
    private string saveFilePath; 

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

        saveFilePath = Path.Combine(Application.persistentDataPath, "levelData.json");
        
        currentLevelIndex = LoadLevelIndex();
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
            // сохранение нового уровня
            SaveLevelIndex(currentLevelIndex);
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

    // сохранение индекса уровня в JSON
    public void SaveLevelIndex(int levelIndex)
    {
        LevelSaveData saveData = new LevelSaveData(levelIndex);
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Level index saved: " + levelIndex);
    }

    // загрузка индекса уровня из JSON
    public int LoadLevelIndex()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            LevelSaveData saveData = JsonUtility.FromJson<LevelSaveData>(json);
            Debug.Log("Level index loaded: " + saveData.savedLevelIndex);
            return saveData.savedLevelIndex;
        }
        else
        {
            return 0; // Если файл не найден, начинаем с 0 уровня
        }
    }
}
