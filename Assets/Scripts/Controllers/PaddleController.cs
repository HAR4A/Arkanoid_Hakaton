using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public static PaddleController Instance { get; private set; }

    private IPaddleMovementController _movementController;
    private bool _isLocked = true;

    public float _speed = 10f;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        IScreenBoundsProvider boundsProvider = new ScreenBoundsProvider(Camera.main);
        _movementController = new PaddleMovementController(transform, boundsProvider, _speed);
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
        _isLocked = false;
    }
}