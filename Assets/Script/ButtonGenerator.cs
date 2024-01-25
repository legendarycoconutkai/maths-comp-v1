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
    static bool[] buttonState;
    string[] operators = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "^" };

    public TextMeshProUGUI displayText;
    private string currentInput = "";
    private double result = 0.0;
    public GameObject equalButton;

    private void OnEnable()
    {
        buttonState = new bool[button.Length];

        equalButton.GetComponent<Button>().onClick.AddListener(() => { CalculateResult(); });

        for (int i = 0; i < button.Length; i++)
        {

            // Activation of button
            button[i].SetActive(true);
            string text = operators[UnityEngine.Random.Range(0, operators.Length)];
            buttonText[i].text = text;
            // Boolean state = true;

            // State of button is initialized to true
            buttonState[i] = true;

            int j = i;

            button[i].GetComponent<Button>().onClick.RemoveAllListeners();
            button[i].GetComponent<Button>().onClick.AddListener(delegate { firstClick(text, j); });
            
        }
    }

    public void firstClick(string buttonValue, int buttonIndex)
    {
        if (buttonState[buttonIndex])
        {
            currentInput += buttonValue;
            buttonState[buttonIndex] = false; //Set button state to false after first click
            UpdateDisplay();
        }

        else
        {
            for (int i = 0; i < currentInput.Length; i++) 
            {
                if (buttonValue == currentInput.Substring(i))
                {
                    currentInput = currentInput.Remove(i,1);
                    buttonState[buttonIndex] = true;
                }
                
            }     
         }
            UpdateDisplay();       
    }

    /*public void firstClick(string buttonValue, int buttonIndex)
    {
        // Check if buttonIndex is within the valid range
        if (buttonIndex < 0 || buttonIndex >= buttonState.Length)
        {
            Debug.LogError("Invalid buttonIndex: " + buttonIndex);
            return;
        }

        // Check if buttonState array has been initialized and has the expected length
        if (buttonState == null || buttonState.Length != button.Length)
        {
            Debug.LogError("Invalid buttonState array");
            return;
        }

        // Check if currentInput is not null
        if (currentInput == null)
        {
            Debug.LogError("currentInput is null");
            return;
        }

        if (buttonState[buttonIndex])
        {
            currentInput += buttonValue;
            buttonState[buttonIndex] = false; // Set the state to false after the first click
        }
        else
        {
            // Handle removing the text (e.g., removing the last character)
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
        }

        UpdateDisplay();
    }*/
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