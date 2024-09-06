using UnityEngine;
public class StartButton : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        GameManager.Instance.StartGame();
    }
}