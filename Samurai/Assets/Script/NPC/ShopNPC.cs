using UnityEngine;

public class ShopNPC : NPCBase
{
    [SerializeField] GameObject interactUI;
    MouseManager mouseManager;

    private bool playerInRange;
    private bool isOpen = false;

    private void Awake()
    {
        mouseManager = FindAnyObjectByType<MouseManager>(); 
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;

        playerInRange = true;

        if(interactUI != null)
            interactUI.SetActive(true);
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;

        if (interactUI != null)
            interactUI.SetActive(false);

        if (isOpen)
        {
            PanelManaager.Instance.Close(panel.Shop);
            mouseManager.HideCursor();
            isOpen = false;
        }
    }

    private void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleShop();
        }
    }

    private void ToggleShop()
    {
        if (!isOpen)
        {
            Debug.Log("¿­¸²");
            PanelManaager.Instance.Open(panel.Shop);
            isOpen = true;
            mouseManager.ShowCursor();
        }
        else
        {
            Debug.Log("´ÝÈû");
            PanelManaager.Instance.Close(panel.Shop);
            mouseManager.HideCursor() ;
            isOpen = false;
        }
    }
}
