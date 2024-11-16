using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpiredItemBehaviour : MonoBehaviour
{
    public bool isExpired;

    private Renderer itemRenderer;
    private BoxCollider2D itemCollider;
    public float moveUpDistance = 1.0f;
    public float fadeDuration = 1.5f;

    void Start()
    {
        isExpired = Random.Range(0, 2) == 0;

        if (isExpired)
        {
            transform.SetParent(transform.parent.parent.Find("Expired Items"));
            //if no expired asset, expired item = grayscaled normal asset
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(50f / 255f, 50f / 255f, 50f / 255f, 1f);
            
        }
        
        itemRenderer = GetComponent<Renderer>();
        itemCollider = GetComponent<BoxCollider2D>();
    }
    private void OnMouseDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.isTrigger && hit.collider.CompareTag("Expiring") && isExpired)
            {
                StartCoroutine(PickUpEffect());
                break;
            }
        }
    }

    private IEnumerator PickUpEffect()
    {
        itemCollider.enabled = false;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + Vector3.up * moveUpDistance;
        float elapsedTime = 0;

        Color startColor = itemRenderer.material.color;

        while (elapsedTime < fadeDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / fadeDuration);

            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            itemRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        itemRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0);
        transform.position = endPosition;

        Destroy(gameObject);

    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
