using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    private bool enableMove = true;
    private Renderer itemRenderer; // Renderer for fading out
    private BoxCollider2D itemCollider; // Collider to disable when fading starts
    public float moveUpDistance = 1.0f; // Distance the object will move up
    public float fadeDuration = 1.5f; // Duration of the fade-out effect

    private void Start()
    {
        itemRenderer = GetComponent<Renderer>();
        itemCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if(enableMove)
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bound"))
        {
            Debug.Log("Out of bounds, return to initial pos");
            //transform.position;
        }

        else if(other.CompareTag("Scanner")) StartCoroutine(PickUpEffect());
    }
    private IEnumerator PickUpEffect()
    {
        enableMove = false;
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
}
