using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.UI;
using TMPro;
using System;

public class buttonGenerator : MonoBehaviour
{
    public GameObject[] button;
    public TextMeshProUGUI[] buttonText;
    static Boolean[] buttonState;
    string[] operators = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "^" };

    public TextMeshProUGUI displayText;
    private string currentInput = "";
    private double result = 0.0;
    public GameObject equalButton;

    private void OnEnable()
    {
        equalButton.GetComponent<Button>().onClick.AddListener(() => { CalculateResult(); });

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
            string text = operators[UnityEngine.Random.Range(0, operators.Length)];
            buttonText[i].text = text;
            //Boolean state = true;
            //buttonState[i] = state;
            button[i].GetComponent<Button>().onClick.RemoveAllListeners();
            button[i].GetComponent<Button>().onClick.AddListener(delegate { firstClick(text); });
            
        }
    }

    public void SecondClick()
    {

    }

    public void firstClick(string buttonValue)
    {
        /*if(state == true)
        {
            currentInput += buttonValue;
            UpdateDisplay();
        }

        else
        {
            currentInput = buttonValue;
            UpdateDisplay();
        } */

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

    private void ButtonListener()
    {

    }
}