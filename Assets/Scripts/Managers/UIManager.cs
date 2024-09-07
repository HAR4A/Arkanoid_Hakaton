using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    [SerializeField] private GameObject[] gameplayUIElements;
    [SerializeField] private GameObject[] editModeUIElements;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject errorPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

   
    public void ToggleUIForGameplay()  //активирует элементы для игрового процесса и скрывает элементы редактирования
    {
        SetActiveForUIElements(gameplayUIElements, true);
        SetActiveForUIElements(editModeUIElements, false);
    }

   
    public void ToggleUIForEditMode() //режим редактирования (если нужно вернуться к редактированию)
    {
        SetActiveForUIElements(gameplayUIElements, false);
        SetActiveForUIElements(editModeUIElements, true);  
    }
    
    public void ShowLosePanel()
    {
        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }
    }

    public void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }
    
    public void ShowErrorPanel()
    {
        if (errorPanel != null)
        {
            errorPanel.SetActive(true);
        }
    }
    
    public void HideErrorPanel()
    {
        if (errorPanel != null)
        {
            errorPanel.SetActive(false);
        }
    }
    
    private void SetActiveForUIElements(GameObject[] uiElements, bool isActive)
    {
        foreach (GameObject element in uiElements)
        {
            element.SetActive(isActive); 
        }
    }
}