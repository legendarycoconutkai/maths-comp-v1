using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Aequatio : MonoBehaviour
{
    //public DefeatPopup defeatPopUp;
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
        if (Input.GetKeyDown("d"))
        {
            SetHealth(-20f);
        }
        if (Input.GetKeyDown("h"))
        {
            SetHealth(20f);
        }
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, Maxhealth);

        healthBar.SetHealth(Health);

        if(Health <= 0)
        {

            gameObject.SetActive(false);
            //defeatPopUp.StartCoroutine(defeatPopUp.defeatPop());
            
            /*
             * Code prompt fail quest
             */
        }
    }

}
