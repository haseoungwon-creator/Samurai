using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    
    private Text text;
    float time;
    void Start()
    {
        
        text = GetComponent<Text>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        float opacity = Mathf.PingPong(time, 1f);
        Color color = Color.white;

        text.color = new Color(color.r,color.g,color.b,opacity);
    }




}
