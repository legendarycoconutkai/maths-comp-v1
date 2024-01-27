using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatPopup : MonoBehaviour
{
    public GameObject defeatPopup;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            defeatPopup.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            defeatPopup.SetActive(false);
        }
    }
}
