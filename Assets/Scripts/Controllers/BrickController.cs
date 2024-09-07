using UnityEngine;

public class BrickController : MonoBehaviour, IBrick
{
    protected int _health = 1;

    public virtual void OnHit()
    {
        _health--;
        
        if (_health <= 0)
        {
            DestroyBrick();
        }
    }
    
    protected virtual void DestroyBrick()
    {
        
        Destroy(gameObject);
    }  
}
