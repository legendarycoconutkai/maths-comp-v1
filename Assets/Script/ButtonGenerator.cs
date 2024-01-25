using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.UI;
using TMPro;
using System;
using org.mariuszgromada.math.mxparser;

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
    public TextMeshProUGUI equalButtonText;

    public GameObject temporaryButton;
    public GameObject temporaryButton2;

    static float question;

    private void OnEnable()
    {
        buttonState = new bool[button.Length];

        // setup equal button
        equalButton.GetComponent<Button>().onClick.AddListener(() => { CalculateResult(); });

        // setup temporary buttons
        temporaryButton.GetComponent<Button>().onClick.AddListener(() => { buttonGeneration(); });
        temporaryButton.GetComponent<Button>().onClick.AddListener(() => { questionGeneration(); });
        temporaryButton2.GetComponent<Button>().onClick.AddListener(() => { ClearInput(); });

        buttonGeneration();
        questionGeneration();
    }

    public void firstClick(string buttonValue, int buttonIndex)
    {
        if (buttonState[buttonIndex])
        {
            currentInput += buttonValue;
            buttonState[buttonIndex] = false; // set button state to false after first click
            setBlack(buttonIndex); // set button to black
            UpdateDisplay();
        }

        else
        {
            for (int i = 0; i < currentInput.Length; i++)
            {
                if (buttonValue == currentInput.Substring(i))
                {
                    currentInput = currentInput.Remove(i, 1);
                    buttonState[buttonIndex] = true;
                    setWhite(buttonIndex); // set button to white
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
            Expression e = new Expression(currentInput);
            result = e.calculate();

            if (result == question)
            {
                currentInput = result.ToString();

                destroyClicked();

                UpdateDisplay();
            }
            
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
    private void setBlack(int buttonIndex)
    {
        button[buttonIndex].GetComponent<Image>().color = Color.black; // turn button to black
        buttonText[buttonIndex].color = Color.white; // turn button text to white
    }
    private void setWhite(int buttonIndex)
    {
        button[buttonIndex].GetComponent<Image>().color = Color.white; // turn button to white
        buttonText[buttonIndex].color = Color.black;// turn button text to black
    }

    private void buttonGeneration()
    {
        for (int i = 0; i < button.Length; i++)
        {
            if (!button[i].activeSelf)
            {
                setWhite(i);

                // Activation of button
                button[i].SetActive(true);

                // Setting the text of the button
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
    }
    private void questionGeneration()
    {
        question = UnityEngine.Random.Range(0, 10);
        equalButtonText.text = ("= " + question.ToString());       
    }
    private void destroyClicked()
    {
        for (int i = 0; i < button.Length; i++)
        {
            if (!buttonState[i])
            {
                // deactivation of button
                button[i].SetActive(false);
            }
        }
    }
    private void ClearInput()
    {
        currentInput = "";
        result = 0.0;
        UpdateDisplay();
    }
}