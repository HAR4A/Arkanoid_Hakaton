using UnityEngine;
using System.Collections;
public class BrickManager : MonoBehaviour
{
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
        BrickController[] bricks = FindObjectsOfType<BrickController>();

        if (bricks.Length == 0)
        {
            GameManager.Instance.HandleWinCondition(); 
        }
        
    }

    public void StopBrickSearch()
    {
        _isSearching = false;
    }
}