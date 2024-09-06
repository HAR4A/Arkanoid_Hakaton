using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public static PaddleController Instance { get; private set; }

    private IPaddleMovementController _movementController;
    private bool _isLocked = true;  // По умолчанию ракетка заблокирована

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
        if (_isLocked) return;  // Если ракетка заблокирована, не реагируем на ввод
        
        float input = Input.GetAxis("Horizontal");
        _movementController.Move(input, Time.deltaTime);
    }

    // Метод для блокировки управления ракеткой
    public void LockPaddle()
    {
        _isLocked = true;
    }

    // Метод для разблокировки управления ракеткой
    public void UnlockPaddle()
    {
        _isLocked = false;
    }
}