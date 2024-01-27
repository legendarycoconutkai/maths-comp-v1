using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPopup : MonoBehaviour
{
    public GameObject victoryPopup;

    void Start()
    {
        victoryPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            victoryPopup.SetActive(true);
            
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            victoryPopup.SetActive(false);
        }
    }
}
