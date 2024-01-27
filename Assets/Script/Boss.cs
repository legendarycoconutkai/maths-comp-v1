using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    public BossController controller;
    public float Health, Maxhealth;

    [SerializeField]
    private HBSetting healthBar;

    

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(Maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            SetHealth(-20f);
        }
        if (Input.GetKeyDown("s"))
        {
            SetHealth(20f);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SetHealth(-Health); // Set health to 0, effectively killing the boss
        }
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, Maxhealth);

        healthBar.SetHealth(Health);

        if (Health <= 0)
        {

            gameObject.SetActive(false);
            controller.StartCoroutine(controller.BossMove());

            healthBar.SetHealth(Maxhealth);

        }
        
    }

    public Boolean activeSelf()
    {
        return gameObject.activeSelf;
    }
}

