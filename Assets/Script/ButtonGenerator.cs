using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;

    private void OnEnable()
    {
        for (int i = 0; i<24; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.GetComponent<ButtonInfo>().buttonText.text = "testing";
            newButton.GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Button" + i + "Clicked"); }) ;
        }
    }
}
