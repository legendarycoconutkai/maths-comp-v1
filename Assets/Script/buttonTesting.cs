using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.UI;
using TMPro;

public class buttonTesting : MonoBehaviour
{
    public GameObject[] button;
    public TextMeshProUGUI[] buttonText;
    string[] operators = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "^" };

    public TextMeshProUGUI displayText;
    private string currentInput = "";
    private double result = 0.0;

    private void OnEnable()
    {
        for(int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
            string text = operators[Random.Range(0, operators.Length)];
            buttonText[i].text = text;
        }
    }
    public void firstClick(string buttonValue)
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
}