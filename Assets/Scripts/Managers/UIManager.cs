using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    // Список элементов UI, которые нужно показать при старте игры
    public GameObject[] gameplayUIElements;
    
    // Список элементов UI, которые нужно скрыть при старте игры
    public GameObject[] editModeUIElements;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Метод, который активирует элементы для игрового процесса и скрывает элементы редактирования
    public void ToggleUIForGameplay()
    {
        SetActiveForUIElements(gameplayUIElements, true);   // Показываем элементы игрового процесса
        SetActiveForUIElements(editModeUIElements, false);  // Скрываем элементы редактирования
    }

    // Метод для режима редактирования (если нужно вернуться к редактированию)
    public void ToggleUIForEditMode()
    {
        SetActiveForUIElements(gameplayUIElements, false);  // Скрываем элементы игрового процесса
        SetActiveForUIElements(editModeUIElements, true);   // Показываем элементы редактирования
    }

    // Метод для массового переключения видимости элементов UI
    private void SetActiveForUIElements(GameObject[] uiElements, bool isActive)
    {
        foreach (GameObject element in uiElements)
        {
            element.SetActive(isActive);  // Включаем или выключаем каждый элемент из массива
        }
    }
}