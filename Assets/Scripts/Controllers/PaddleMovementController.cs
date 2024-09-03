using UnityEngine;

public class PaddleMovementController : IPaddleMovementController
{
    private Transform _paddleTransform;
    private IScreenBoundsProvider _screenBoundsProvider;
    private float _speed;
    private float _halfPaddleWidth;

    public PaddleMovementController(Transform transform, IScreenBoundsProvider boundsProvider, float speed)
    {
        _paddleTransform = transform;
        _screenBoundsProvider = boundsProvider;
        this._speed = speed;

        //ширина в мировых координатах
        _halfPaddleWidth = transform.GetComponent<Renderer>().bounds.size.x / 2;
    }

    public void Move(float direction, float deltaTime)
    {
        float newPositionX = _paddleTransform.position.x + direction * _speed * deltaTime;

        //ограничение движения с учетом реальной ширины платформы и границ экрана
        float clampedX = Mathf.Clamp(newPositionX, _screenBoundsProvider.GetLeftBoundary() + _halfPaddleWidth, _screenBoundsProvider.GetRightBoundary() - _halfPaddleWidth);
      
        _paddleTransform.position = new Vector3(clampedX, _paddleTransform.position.y, _paddleTransform.position.z);
    }
}