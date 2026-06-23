using UnityEngine;
using UnityEngine.UI;

public class BlinkingTextUI : MonoBehaviour
{
    
    private Text text;
    float elapsedTime;
    void Start()
    {
        
        text = GetComponent<Text>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        float opacity = Mathf.PingPong(elapsedTime, 1f);
        Color color = Color.white;

        text.color = new Color(color.r,color.g,color.b,opacity);
    }




}
