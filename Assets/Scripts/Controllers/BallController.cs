using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    public static BallController Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _livesText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    public new Rigidbody2D rigidbody { get; private set; }
    private float _speed = 500f;
    private int _lives = 3;
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
        LockBall();
        UpdateLivesText(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<DeathZone>(out var deathZone))
        {
            _lives--;  
            UpdateLivesText();

            if (_lives <= 0)
            {
                Debug.Log("Game Over! Lives are 0.");
               
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

        _isLocked = false;
        this.rigidbody.simulated = true;
        Vector2 _force = new Vector2(Random.Range(-1f, 1f), -1f);
        this.rigidbody.AddForce(_force.normalized * this._speed);
    }
}
