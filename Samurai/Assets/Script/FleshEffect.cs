using System.Collections;
using UnityEngine;
public class FleshEffect : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Material originarMaterial;
    [SerializeField] Material flashMaterial;
    [SerializeField] float duraion;

    private Coroutine coroutine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originarMaterial = spriteRenderer.material;
    }

    public void Flash()
    {
        if (coroutine != null)
        {
            StopCoroutine(FlashRoutine());
        }
        coroutine = StartCoroutine(FlashRoutine());
    }
    IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(duraion);

        spriteRenderer.material = originarMaterial;
        coroutine = null;
    }
    
}
