using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClassicUIManager : MonoBehaviour
{
    public static ClassicUIManager Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

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

    
    public void UpdateLevelText(int levelNumber)
    {
        levelText.text = "УРОВЕНЬ: " + levelNumber;
    }
    
    
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

   
    public void HideWinPanel()
    {
        winPanel.SetActive(false);
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }

    
    public void HideLosePanel()
    {
        losePanel.SetActive(false);
    }
}