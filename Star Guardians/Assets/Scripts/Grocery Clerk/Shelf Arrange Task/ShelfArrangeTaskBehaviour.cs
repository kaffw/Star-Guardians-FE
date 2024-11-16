using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfArrangeTaskBehaviour : MonoBehaviour
{
    private GameObject topShelf, midShelf, botShelf;

    public GameObject[] topShelfItems = new GameObject[4],
                        midShelfItems = new GameObject[4],
                        botShelfItems = new GameObject[4];

    public GameObject unarrangedHolder;
    private void Start()
    {
        Unarranged();
    }

    void Unarranged()
    {
        int topItem = Random.Range(0, 4);
        int midItem = Random.Range(0, 4);
        int botItem = Random.Range(0, 4);

        for (int i = 0; i < 4; i++)
        {
            if (i != topItem)
            {
                topShelfItems[i].transform.SetParent(unarrangedHolder.transform);
                topShelfItems[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 3), Random.Range(-3, 4), 0);
            }

            if (i != midItem)
            {
                midShelfItems[i].transform.SetParent(unarrangedHolder.transform);
                midShelfItems[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 3), Random.Range(-3, 4), 0);
            }

            if (i != botItem)
            {
                botShelfItems[i].transform.SetParent(unarrangedHolder.transform);
                botShelfItems[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 3), Random.Range(-3, 4), 0);
            }
        }
    }
}
//topShelf = transform.Find("Top Shelf").gameObject;
//midShelf = transform.Find("Mid Shelf").gameObject;
//botShelf = transform.Find("Bottom Shelf").gameObject;

//unarrangedHolder = transform.Find("Unarranged")?.gameObject;