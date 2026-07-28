using UnityEngine;
using UnityEngine.UI;

public class BlinkingTextUI : MonoBehaviour
{
    private Color baseColor;
    private Text text;
    float elapsedTime;
    void Start()
    {
        baseColor = Color.white;
        text = GetComponent<Text>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        float opacity = Mathf.PingPong(elapsedTime, 1f);

        text.color = new Color(baseColor.r, baseColor.g, baseColor.b,opacity);
    }




}
