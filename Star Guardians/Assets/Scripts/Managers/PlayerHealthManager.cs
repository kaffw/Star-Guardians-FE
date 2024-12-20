using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public Image[] healthPoints;
    private int cC;

    void Start()
    {
        cC = gameObject.transform.childCount;
        healthPoints = new Image[cC];
        
        for(int i=0; i<cC; i++)
        {
            healthPoints[i] = gameObject.transform.GetChild(i).GetComponent<Image>();
        }
    }

    void Update()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        int health = CharacterManager.hp;

        for(int i=0; i < cC; i++)
        {
            if(i < health)
            {
                healthPoints[i].color = Color.red;
            }
            else
            {
                healthPoints[i].color = Color.black;
            }
        }
    }
}
