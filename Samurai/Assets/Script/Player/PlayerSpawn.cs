using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private void Awake()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Debug.Log(GameManager.Instance.CurrentState);
        if (GameManager.Instance.Player != null)
        {
            GameManager.Instance.Player.transform.position = spawnPoint.position;
            return;
        }

        if (GameManager.Instance.CurrentState == GameState.Story) return;

        GameObject playerPrefab = Resources.Load<GameObject>("Player");

        if (playerPrefab == null) return;

        GameObject player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);

        GameManager.Instance.SetPlayer(player);

    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null && GameManager.Instance.Player == gameObject)
        {
            GameManager.Instance.SetPlayer(null);
        }
    }
}
