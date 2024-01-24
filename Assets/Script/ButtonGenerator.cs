using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;


public class ButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;

    private void OnEnable()
    {
        string[] operators = {"+", "-", "*", "/", "^", "%"};

        for (int i = 0; i<24; i++)
        {
            int counter = i+1;
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            string buttonText = operators[Random.Range(0,operators.Length)];
            newButton.GetComponent<ButtonInfo>().buttonText.text = buttonText;

            Button button = newButton.GetComponent<Button>();
            newButton.GetComponent<Button>().onClick.RemoveAllListeners();
            newButton.GetComponent<Button>().onClick.AddListener(() => { OnButtonClick(counter, buttonText); }) ;
        }


    }

    private void OnButtonClick(int buttonNumber, string buttonText)
    {
        Debug.Log("Button " + buttonNumber + " Clicked Text: " + buttonText);
    }
}
