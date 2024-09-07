using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class BrickManager : MonoBehaviour
{
    public static BrickManager Instance { get; private set; }

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
    private bool _isSearching = false;
    
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
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    public bool AreBricksPresent()
    {
        BrickController[] bricks = FindObjectsOfType<BrickController>();
        return bricks.Length > 0;
    }
    
    private void CheckForBricks()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        BrickController[] bricks = FindObjectsOfType<BrickController>();

        if (bricks.Length == 0)
        {   
            if (currentScene.buildIndex == 1)
            {
                ClassicGameManager.Instance.HandleWinCondition();
            }
            
            else if (currentScene.buildIndex == 0)
            {
                GameManager.Instance.HandleWinCondition(); 
            }
        }
    }

    public void StopBrickSearch()
    {
        _isSearching = false;
    }
    
    
    
    public void ClearBricks()
    {
        foreach (var brick in FindObjectsOfType<BrickController>())
        {
            Destroy(brick.gameObject);
        }
    }
}