using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatPopup : MonoBehaviour
{
    //public GameObject defeatPopup;

    void Update()
    {

    }

    public IEnumerator defeatPop()
    {
        gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        gameObject.SetActive(false);
    }
}
