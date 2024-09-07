using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public static BallController Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _livesText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    public new Rigidbody2D rigidbody { get; private set; }
    
    private float _speed = 600f;
    private int _lives = 5;
    private int _score;
    private bool _isLocked = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        this.rigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        UpdateLivesText();  
        
        Scene currentScene = SceneManager.GetActiveScene();
        
        if (currentScene.buildIndex == 1)
        {
            UnlockBall();
        }
        else if (currentScene.buildIndex == 0)
        {
            LockBall();
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        if (other.TryGetComponent<DeathZone>(out var deathZone))
        {
            _lives--;  
            UpdateLivesText();

            if (_lives <= 0)
            {
                if (currentScene.buildIndex == 0)
                {
                    GameManager.Instance.GameOver();
                }
                else if (currentScene.buildIndex == 1)
                {
                    LockBall();
                    PaddleController.Instance.LockPaddle();
                    ClassicUIManager.Instance.ShowLosePanel(); 
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isLocked) return;

        IBrick brick = collision.gameObject.GetComponent<IBrick>();
        if (brick != null)
        {
            _score++;
            UpdateScoreText();
            brick.OnHit();
        }
    }

    private void UpdateScoreText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "СЧЕТ: " + _score.ToString();
        }
    }
    
    private void UpdateLivesText()
    {
        if (_livesText != null)
        {
            _livesText.text = "ЖИЗНИ: " + _lives.ToString();
        }
    }

    public void LockBall()
    {
        _isLocked = true;
        this.rigidbody.velocity = Vector2.zero;  
        this.rigidbody.simulated = false; 
    }

    public void UnlockBall()
    {
        if (!_isLocked) return;

        this.transform.position = new Vector3(0f, -4.14f, 0f);
        
        this.rigidbody.velocity = Vector2.zero;
    
        _isLocked = false;
        this.rigidbody.simulated = true;
        
        Vector2 _force = new Vector2(Random.Range(-1f, 1f), -1f);
        this.rigidbody.AddForce(_force.normalized * this._speed);
    }
}



