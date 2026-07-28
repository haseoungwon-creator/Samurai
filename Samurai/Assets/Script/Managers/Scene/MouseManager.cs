using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public bool ismMouse {  get; private set; }
    int openCount = 0;
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        ismMouse = false;
    }

    public void ShowCursor()
    {
        openCount++;
        ismMouse=true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCursor()
    {
        openCount--;
        if (openCount > 0) return;
        ismMouse = false;
        Cursor.visible = false;
        Cursor.lockState= CursorLockMode.Confined;
    }

    private void OnDestroy()
    {
        openCount = 0;
        ismMouse = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

    }
}
