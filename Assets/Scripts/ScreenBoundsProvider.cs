using UnityEngine;

public class ScreenBoundsProvider : IScreenBoundsProvider
{
    private Camera _mainCamera;

    public ScreenBoundsProvider(Camera camera)
    {
        _mainCamera = camera;
    }

    public float GetLeftBoundary()
    {
        return _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, _mainCamera.transform.position.z)).x;
    }

    public float GetRightBoundary()
    {
        return _mainCamera.ViewportToWorldPoint(new Vector3(1, 0, _mainCamera.transform.position.z)).x;
    }
}