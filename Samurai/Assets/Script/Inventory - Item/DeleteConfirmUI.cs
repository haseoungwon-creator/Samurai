using UnityEngine;

public class DeleteConfirmUI : MonoBehaviour
{
    public void Confirm()
    {
        ItemDeleteManager.Instance.ConfirmDelete();
    }

    public void Cancel()
    {
        ItemDeleteManager.Instance.CancelDelete();
    }
}
