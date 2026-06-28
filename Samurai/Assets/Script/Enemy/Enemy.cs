using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private void Start()
    {
        EnemyManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        if(EnemyManager.Instance != null)
        EnemyManager.Instance.Unregister(this);
    }

    public void Die()
    {
        EnemyManager.Instance.Unregister(this);
        Destroy(gameObject);
    }
}
