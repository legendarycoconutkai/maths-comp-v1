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
            int counter = i+1;
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.GetComponent<ButtonInfo>().buttonText.text = "Button"+i;
            newButton.GetComponent<Button>().onClick.RemoveAllListeners();
            newButton.GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Button" + i + "Clicked"); }) ;
        }
    }
}
