using UnityEngine;
using UnityEngine.UI;

public class ToolTipManger : MonoBehaviour
{
    public static ToolTipManger Instance;
    
    [SerializeField] GameObject tooltipPanel;

    [SerializeField] Text itemNameText;
    [SerializeField] Text descriptionText;

    private void Awake()
    {
        Instance = this;
        tooltipPanel.SetActive(false);
    }

    public void Show(ItemData dataa)
    {
        tooltipPanel.SetActive(true);

        itemNameText.text = dataa.name;
        descriptionText.text = dataa.description;
    }

    public void Hide()
    {
        tooltipPanel.SetActive(false);

        itemNameText.text = "";
        descriptionText.text = "";
    }
}
