using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController Instance { get; private set; }

    public new Rigidbody2D rigidbody { get; private set; }
    public float _speed = 500f;
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isLocked) return;  // Игнорируем столкновения, если мяч заблокирован

        IBrick brick = collision.gameObject.GetComponent<IBrick>();
        if (brick != null)
        {
            brick.OnHit();
        }  
    }
    
    public void LockBall()
    {
        _isLocked = true;
        this.rigidbody.velocity = Vector2.zero;  // Останавливаем мяч
        this.rigidbody.simulated = false;  // Отключаем физику
    }

    public void UnlockBall()
    {
        if (!_isLocked) return;
        
        _isLocked = false;
        this.rigidbody.simulated = true;  // Включаем физику
        Vector2 _force = new Vector2(Random.Range(-1f, 1f), -1f);
        this.rigidbody.AddForce(_force.normalized * this._speed);
    }
}