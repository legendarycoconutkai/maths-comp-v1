using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    //public Boss2Controller controller;
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
        healthBar.SetMaxHealth(Maxhealth);
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, Maxhealth);

        healthBar.SetHealth(Health);

        if (Health <= 0)
        {

            gameObject.SetActive(false);
            //controller.StartCoroutine(controller.Boss2Move());

        }

    }

    public Boolean activeSelf()
    {
        return gameObject.activeSelf;
    }
}
