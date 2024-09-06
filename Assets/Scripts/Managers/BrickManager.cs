using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public static BrickManager Instance { get; private set; }
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
    }
}