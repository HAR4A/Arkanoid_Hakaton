using UnityEngine;

public class WallsController : MonoBehaviour
{
    [SerializeField] private float _bottomOffset = 1f; //смещение нижней стены
    [SerializeField] private float _extraLength = 1f; //смещение вних боковых стен
    private Camera _mainCamera;

    private BoxCollider2D leftWall, rightWall, topWall, bottomWall;

    private void Start()
    {
        _mainCamera = Camera.main;
        
        leftWall = transform.Find("LeftWall").GetComponent<BoxCollider2D>();
        rightWall = transform.Find("RightWall").GetComponent<BoxCollider2D>();
        topWall = transform.Find("TopWall").GetComponent<BoxCollider2D>();
        bottomWall = transform.Find("BottomWall").GetComponent<BoxCollider2D>();
        
        UpdateWalls();
    }

    private void Update()
    {
        UpdateWalls();
    }

    private void UpdateWalls()
    {
        float _camHeight = 2f * _mainCamera.orthographicSize;
        float _camWidth = _camHeight * _mainCamera.aspect;
        
        float _wallThickness = 1f; 

        //левая стена
        leftWall.size = new Vector2(_wallThickness, _camHeight + 2 * _extraLength);
        leftWall.offset = new Vector2(-_camWidth / 2f - _wallThickness / 2f, -_extraLength);

        //правая стена
        rightWall.size = new Vector2(_wallThickness, _camHeight + 2 * _extraLength);
        rightWall.offset = new Vector2(_camWidth / 2f + _wallThickness / 2f, -_extraLength);

        //верхняя стена
        topWall.size = new Vector2(_camWidth, _wallThickness);
        topWall.offset = new Vector2(0f, _camHeight / 2f + _wallThickness / 2f);

        //нижняя стена
        bottomWall.size = new Vector2(_camWidth, _wallThickness);
        bottomWall.offset = new Vector2(0f, -_camHeight / 2f - _wallThickness / 2f - _bottomOffset);
    }
}