using System.Collections;
using UnityEngine;

public class PriceTagBehaviour : MonoBehaviour
{
    public string targetTag;
    private Collider2D c2d;
    public Vector3 defaultPos;
    private Vector3 offset;
    private bool isArranged = false;

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

        bool foundTagless = false;

        foreach (RaycastHit2D hitInfo in hitInfos)
        {
            if (hitInfo.collider != null && hitInfo.collider.CompareTag("Tagless"))
            {
                if (hitInfo.collider.gameObject.transform.childCount < 1)
                {
                    transform.SetParent(hitInfo.collider.transform);
                    isArranged = true;
                    foundTagless = true;
                    break;
                }
            }
        }

        if (!foundTagless)
        {
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
