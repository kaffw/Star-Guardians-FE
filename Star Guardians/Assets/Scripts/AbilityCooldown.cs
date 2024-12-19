using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    public static float devourCooldown;
    public static bool abilityInAction;
    public Image abilityCooldownIndicator;

    void Awake()
    {
        abilityCooldownIndicator = GameObject.Find("Ability Container Shadow").GetComponent<Image>();
    }

    void Start()
    {
        devourCooldown = 1f;
        abilityInAction = false;
    }

    void Update()
    {
        devourCooldown -= Time.deltaTime;
        abilityCooldownIndicator.fillAmount = devourCooldown;

        if(devourCooldown <= 0)
        {
            abilityInAction = false;
        }
    }
}
