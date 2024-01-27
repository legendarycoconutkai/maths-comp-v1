using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPopup : MonoBehaviour
{
    public GameObject victoryPopup;



    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator victoryPop()
    {
        victoryPopup.SetActive(true);

        yield return new WaitForSeconds(3);

        victoryPopup.SetActive(false);
    }
}