using UnityEngine;

public class BrickController : MonoBehaviour, IBrick
{
    protected int health = 1;

    public virtual void OnHit()
    {
        health--;
        if (health <= 0)
        {
            DestroyBrick();
        }
    }

    protected virtual void DestroyBrick()
    {
        
        Destroy(gameObject);
    }  
}
