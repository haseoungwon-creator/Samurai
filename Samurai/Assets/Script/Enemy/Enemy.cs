using UnityEngine;

public class Enemy : MonoBehaviour
{

    
    private void OnEnable()
    {
        EnemyManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        EnemyManager.Instance.Unregister(this);
    }

    public void Die()
    {
        EnemyManager.Instance.Unregister(this);
        Destroy(gameObject);
    }
}
