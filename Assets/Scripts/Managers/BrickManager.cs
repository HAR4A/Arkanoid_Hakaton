using UnityEngine;
using System.Collections;
public class BrickManager : MonoBehaviour
{
    private bool _isSearching = false;

    // Этот метод будет вызываться при старте игры
    public void CheckForBricksContinuously()
    {
        _isSearching = true;
        StartCoroutine(BrickSearchRoutine());
    }

    private IEnumerator BrickSearchRoutine()
    {
        while (_isSearching)
        {
            CheckForBricks();
            yield return new WaitForSeconds(0.5f); // Интервал поиска в 1 секунду
        }
    }

    
    public bool AreBricksPresent()
    {
        BrickController[] bricks = FindObjectsOfType<BrickController>();
        return bricks.Length > 0;
    }
    
    private void CheckForBricks()
    {
        BrickController[] bricks = FindObjectsOfType<BrickController>();

        if (bricks.Length == 0)
        {
            GameManager.Instance.HandleWinCondition(); 
        }
        /*else
        {
            Debug.Log($"Найдено {bricks.Length} кирпичиков на сцене.");
        }*/
    }

    public void StopBrickSearch()
    {
        _isSearching = false;
    }
}

    /*public static BrickManager Instance { get; private set; }
    private int totalBricks;

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

    private void Start()
    {
        // Находим все кирпичи на сцене
        BrickController[] bricks = FindObjectsOfType<BrickController>();
        totalBricks = bricks.Length;
    }

    private void Update()
    {
        // Проверяем количество кирпичей на сцене в каждом кадре
        BrickController[] bricks = FindObjectsOfType<BrickController>();

        // Если кирпичей нет, вызываем метод победы
        if (bricks.Length == 0)
        {
            GameManager.Instance.HandleWinCondition();
        }
    }*/
