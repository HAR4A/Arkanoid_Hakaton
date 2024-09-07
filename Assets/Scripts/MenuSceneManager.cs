using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public void ClassicLevel()
    {
      SceneManager.LoadScene(2);  
    }

    public void EditedLevel()
    {
        SceneManager.LoadScene(1);  
    }

    public void Exit()
    {
        Application.Quit();
    }
}
