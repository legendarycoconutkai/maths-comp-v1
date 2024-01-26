using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
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
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, Maxhealth);

        healthBar.SetHealth(Health);
    }
}

