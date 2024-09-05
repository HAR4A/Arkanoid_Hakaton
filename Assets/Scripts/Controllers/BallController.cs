using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public new Rigidbody2D rigidbody {get; private set;}
    public float _speed = 500f;

    private void Awake()
    {
        this.rigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 _force = Vector2.zero;
        _force.x = Random.Range(-1f, 1f);
        _force.y = -1f;
        
        this.rigidbody.AddForce(_force.normalized * this._speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IBrick brick = collision.gameObject.GetComponent<IBrick>();
        if (brick != null)
        {
            brick.OnHit();
        }  
    }
}
