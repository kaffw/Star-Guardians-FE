using System.Collections;
using UnityEngine;

public class EnterEstablishmentBehaviour : MonoBehaviour
{
    public GameObject indicator;
    public GameObject targetLocation;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            indicator.SetActive(true);
            StartCoroutine(WaitForInteraction());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            indicator.SetActive(false);
            StopAllCoroutines();
        }
    }

    private IEnumerator WaitForInteraction()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterEstablishment();
                yield break;
            }
            yield return null;
        }
    }

    private void EnterEstablishment()
    {
        Debug.Log("Establishment entered");
        player.transform.position = targetLocation.transform.position + new Vector3(0f, 1f, 0f);
    }
}
