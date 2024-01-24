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
            int counter = 1;
            counter++;
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.GetComponent<ButtonInfo>().buttonText.text = "Button"+i;
            newButton.GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Button" + i + "Clicked"); }) ;
        }
    }
}
