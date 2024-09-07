using UnityEngine;
using UnityEngine.SceneManagement;
public class PaddleController : MonoBehaviour
{
    public static PaddleController Instance { get; private set; }

    private IPaddleMovementController _movementController;
    private bool _isLocked = true; 

    private float _speed = 30f;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
  
        IScreenBoundsProvider boundsProvider = new ScreenBoundsProvider(Camera.main);
        _movementController = new PaddleMovementController(transform, boundsProvider, _speed);
        
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 0)
        {
            _isLocked = true; 
        }
        else if (currentScene.buildIndex == 1)
        {
            _isLocked = false; 
        }
    }

    private void Update()
    {
        if (_isLocked) return;
        
        
        float input = Input.GetAxis("Horizontal");
        _movementController.Move(input, Time.deltaTime);
    }
    
    public void LockPaddle()
    {
        _isLocked = true;
    }
    
    public void UnlockPaddle()
    {
        this.transform.position = new Vector3(0f, -5.15f, 0f);
        _isLocked = false;
    }
}