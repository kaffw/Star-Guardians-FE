using System.Collections;
using UnityEngine;

public class ShelfItemBehaviour : MonoBehaviour
{
    public string targetRow;
    private Collider2D c2d;
    public Vector3 defaultPos;
    private Vector3 offset;
    private bool isArranged = false;
    private bool resetter = false;

    private void Start()
    {
        c2d = GetComponent<Collider2D>();
        StartCoroutine(SetDefaultPosition());
    }

    private void OnMouseDown()
    {
        if (isArranged) return;
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (isArranged) return;
        transform.position = GetMouseWorldPosition() + offset;
    }

    private void OnMouseUp()
    {
        if (isArranged) return;

        c2d.enabled = false;

        Vector2 mousePosition = GetMouseWorldPosition();
        RaycastHit2D[] hitInfos = Physics2D.RaycastAll(mousePosition, Vector2.zero);

        bool hitShelf = false;  // To track if we hit a "Shelf" tag

        foreach (var hitInfo in hitInfos)
        {
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Shelf"))
                {
                    // Check if the name matches the target row
                    if (hitInfo.collider.gameObject.name == targetRow)
                    {
                        transform.SetParent(hitInfo.collider.transform);
                        isArranged = true;
                        hitShelf = true;  // If hit a valid shelf, break the loop
                        break;
                    }
                }
            }
        }

        if (!hitShelf)
        {
            resetter = true;
            //ResetToDefaultPosition();
        }

        if(!isArranged && resetter)
        {
            ResetToDefaultPosition();
            resetter = false;
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

/*
 * mouse pos movement
 * 
 *
 *
 * 
 */