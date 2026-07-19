using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject interactionUI;

    [SerializeField] bool isShopNPC;

    bool canInteract;
    bool isopen;

    private void Start()
    {
        interactionUI.SetActive(false);

    }

    private void Update()
    {
        if (!canInteract) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void Interact()
    {
        if (isShopNPC)
        {
            GameManager.Instance.SetState(GameState.Shop);

            PanelManaager.Instance.Open(panel.Shop);
        }
        else
        {
            GameManager.Instance.SetState(GameState.Story);

            PanelManaager.Instance.Open(panel.Dialogue);
        }
    }


    private void CloseShop()
    {
        PanelManaager.Instance.Close(panel.Shop);

        GameManager.Instance.SetState(GameState.Playing);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        canInteract = true;

        interactionUI.SetActive(true);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        canInteract = false;
        
        interactionUI.SetActive(false);

        CloseShop();
    }
}
