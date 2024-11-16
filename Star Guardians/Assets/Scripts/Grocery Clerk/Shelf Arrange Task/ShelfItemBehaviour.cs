using System.Collections;
using UnityEngine;

public class ShelfItemBehaviour : MonoBehaviour
{
    public string targetRow;
    private Collider2D c2d;
    public Vector3 defaultPos;
    private Vector3 offset;

    private void Start()
    {
        c2d = GetComponent<Collider2D>();
        StartCoroutine(SetDefaultPosition());
    }

    private void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    private void OnMouseUp()
    {
        c2d.enabled = false;

        Vector2 mousePosition = GetMouseWorldPosition();
        RaycastHit2D hitInfo = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hitInfo.collider != null)
        {
            Debug.Log("Hit object: " + hitInfo.collider.gameObject.name);

            if (hitInfo.collider.CompareTag("Shelf"))
            {
                if (hitInfo.collider.gameObject.name == targetRow)
                {
                    Debug.Log("Correct Position");
                    transform.SetParent(hitInfo.collider.transform);
                }
                else
                {
                    Debug.Log("Wrong Position");
                    ResetToDefaultPosition();
                }
            }
            else
            {
                Debug.Log("No valid shelf hit");
                ResetToDefaultPosition();
            }
        }
        else
        {
            Debug.Log("No object hit at mouse position");
            ResetToDefaultPosition();
        }

        c2d.enabled = true;
    }

    private void ResetToDefaultPosition()
    {
        transform.position = defaultPos;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private IEnumerator SetDefaultPosition()
    {
        yield return new WaitForSeconds(0.1f);
        defaultPos = transform.position;
    }
}