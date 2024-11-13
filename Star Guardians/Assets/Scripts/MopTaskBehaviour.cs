using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopTaskBehaviour : MonoBehaviour
{
    public GameObject puddle;
    public GameObject mop;

    void Start()
    {
        Time.timeScale = 1f;

        for(int i = 0; i < Random.Range(2, 5); i++)
            Instantiate(puddle, new Vector3(Random.Range(-3, 4), Random.Range(-3, 4), 0), transform.rotation);
        
        Instantiate(mop);        
    }

}

/*
    x = -5, 5
    y = -3, 3
 */
