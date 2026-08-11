using UnityEngine;

public class MouseManager : Singleton<MouseManager>
{
    public bool ismMouse {  get; private set; }
    int openCount = 0;
    protected override void Awake()
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

    protected override void OnDestroy()
    {
        base.OnDestroy();
        openCount = 0;
        ismMouse = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void ResetMouse()
    {
        ismMouse = false;
        openCount = 0;
    }
}
