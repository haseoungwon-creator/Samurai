using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    [SerializeField] Text goldText;


    private void Update()
    {
        Refresh();
    }
    private void Refresh()
    {
        goldText.text = GoldManager.Instance.Gold.ToString()+"G";
    }
}
