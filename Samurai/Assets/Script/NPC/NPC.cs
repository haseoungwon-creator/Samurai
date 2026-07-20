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


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (GameManager.Instance.Currentstate == GameState.Shop)
                CloseShop();

            else
            {
                if (!canInteract) return;
                Interact();
            }
        }
    }

    private void Interact()
    {
        if (isShopNPC)
        {
            MouseManager.Instance.ShowCursor();

            GameManager.Instance.SetState(GameState.Shop);

            PanelManaager.Instance.Open(panel.Shop);

            interactionUI.SetActive(false);
        }
        else
        {
            GameManager.Instance.SetState(GameState.Story);

            PanelManaager.Instance.Open(panel.Dialogue);
        }
    }


    private void CloseShop()
    {
        MouseManager.Instance.HideCursor();

        PanelManaager.Instance.Close(panel.Shop);

        GameManager.Instance.SetState(GameState.Playing);

        interactionUI.SetActive(true);
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

    }
}
