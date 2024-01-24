using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;


public class ButtonDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buttonPrefab;
    public GameObject buttonParent;

    public TextMeshProUGUI displayText;
    private string currentInput = "";
    private double result = 0.0;
    public GameObject equalButton;

    private void OnEnable()
    {
        string[] operators = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "^" };

        for (int i = 0; i < 24; i++)
        {
            int counter = i + 1;
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            string buttonText = operators[Random.Range(0, operators.Length)];
            newButton.GetComponent<ButtonInfo>().buttonText.text = buttonText;

            Button button = newButton.GetComponent<Button>();
            newButton.GetComponent<Button>().onClick.RemoveAllListeners();
            newButton.GetComponent<Button>().onClick.AddListener(() => { OnButtonClick(buttonText); });
        }

        equalButton.GetComponent<Button>().onClick.AddListener(() => { CalculateResult(); });
    }
    /*private void OnButtonClick(int buttonNumber, string buttonText)
    {
        Debug.Log("Button " + buttonNumber + " Clicked Text: " + buttonText);
    }*/

    public void OnButtonClick(string buttonValue)
    {
        currentInput += buttonValue;
        UpdateDisplay();
    }
    public void CalculateResult()
    {
        try
        {
            result = System.Convert.ToDouble(new System.Data.DataTable().Compute(currentInput, ""));

            currentInput = result.ToString();

            UpdateDisplay();
        }
        catch (System.Exception)
        {
            currentInput = "Error";
            UpdateDisplay();
        }
    }
    private void UpdateDisplay()
    {
        displayText.text = currentInput;
    }

    private void ButtonEnable()
    {

    }
}
