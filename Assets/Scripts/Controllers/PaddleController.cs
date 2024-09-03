using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private IPaddleMovementController _movementController;

    public float _speed = 10f;

    private void Start()
    {
        IScreenBoundsProvider boundsProvider = new ScreenBoundsProvider(Camera.main);
        _movementController = new PaddleMovementController(transform, boundsProvider, _speed);
    }

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        _movementController.Move(input, Time.deltaTime);
    }
}
