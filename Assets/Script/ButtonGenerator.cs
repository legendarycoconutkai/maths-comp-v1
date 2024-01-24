using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;


public class ButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;

    public TextMeshProUGUI displayText;
    private string currentInput = "";
    private double result = 0.0;
    public GameObject equalButton;

    private void OnEnable()
    {
        string[] operators = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "^" };
        GameObject[] buttons = new GameObject[24];

        for (int i = 0; i < 24; i++)
        {
            buttons[i] = Instantiate(buttonPrefab, buttonParent.transform);
            string buttonText = operators[Random.Range(0, operators.Length)];
            buttons[i].GetComponent<ButtonInfo>().buttonText.text = buttonText;
            int j = i;
            Button button = buttons[i].GetComponent<Button>();
            buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
            buttons[i].GetComponent<Button>().onClick.AddListener(() => { OnButtonClick(buttons[j]); });
        }

        equalButton.GetComponent<Button>().onClick.AddListener(() => { CalculateResult(); });
    }
    /*private void OnButtonClick(int buttonNumber, string buttonText)
    {
        Debug.Log("Button " + buttonNumber + " Clicked Text: " + buttonText);
    }*/ 

    public void OnButtonClick(GameObject button)
    {
        currentInput += button.GetComponent<ButtonInfo>().buttonText.text;
        UpdateDisplay();
        Color col = button.GetComponent<Image>().color;
        col.a = 30;
        button.GetComponent<Image>().color = col;
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
}