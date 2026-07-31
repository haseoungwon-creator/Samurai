using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] string pointID;

    public string SpawnPointID => pointID;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}
