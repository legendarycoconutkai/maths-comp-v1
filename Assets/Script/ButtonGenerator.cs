using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.UI;
using TMPro;
using System;
using org.mariuszgromada.math.mxparser;
using Unity.VisualScripting;

public class buttonGenerator : MonoBehaviour
{

    public Boss boss1;
    public Boss2 boss2;
 
    public int damageCount = 0;

    public GameObject[] button;
    public TextMeshProUGUI[] buttonText;
    static bool[] buttonState;
    static int[] textPosition;
    string[] operators = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "\u00d7", "\u00f7", "^" };

    public TextMeshProUGUI displayText;
    public TextMeshProUGUI damageText;
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
        textPosition = new int[button.Length];

        // setup equal button
        equalButton.GetComponent<Button>().onClick.AddListener(() => { CalculateResult(); });

        // setup temporary buttons
        temporaryButton.GetComponent<Button>().onClick.AddListener(() => { buttonGeneration(); });
        temporaryButton.GetComponent<Button>().onClick.AddListener(() => { questionGeneration(); });
        temporaryButton2.GetComponent<Button>().onClick.AddListener(() => { ClearInput(true); });

        //StartCoroutine (buttonGeneration());
        buttonGeneration();
        questionGeneration();
    }
    public void buttonClick(string buttonValue, int buttonIndex)
    {
        if (buttonState[buttonIndex])
        {
            currentInput += buttonValue; // add button text to display
            textPosition[buttonIndex] = currentInput.Length - 1; // save the position of the text in display
            buttonState[buttonIndex] = false; // set button state to false after first click
            setBlack(buttonIndex); // set button to black
            damageCount++;
        }

        else
        {
            currentInput = currentInput.Remove(textPosition[buttonIndex], 1); // remove button text from display

            for (int i = 0; i < textPosition.Length; i++) // minus 1 from the position of text in front of removed text
            {
                if (textPosition[i] > textPosition[buttonIndex])
                {
                    textPosition[i] = textPosition[i] - 1;
                }
            }

            buttonState[buttonIndex] = true; // set button state back to true after second click
            setWhite(buttonIndex); // set button to white
            damageCount--;
        }

        UpdateDisplay();
    }
    public void CalculateResult()
    {
        try
        {
            
            Expression e = new Expression(currentInput);
            result = e.calculate();

            if (result == question) // only update result if answer is correct
            {
                StartCoroutine(DamageCounter());
                ClearInput(false);
                destroyClicked();
                equalButton.GetComponent<Image>().color = Color.green; // turns button green as feedback if correct
                Invoke(nameof(setEqualButtonWhite), (float)0.2);

                //Damage Calculation
                if (boss1.activeSelf())
                {
                    boss1.SetHealth(-damageCount);
                }

                else if (boss2.activeSelf()){
                    boss2.SetHealth(-damageCount);
                }//-------------------New Method to be done-----------------------------
                
                StartCoroutine(DelayCaller());
            }
            else // turns button red as feedback if wrong
            {
                equalButton.GetComponent<Image>().color = Color.red;
                Invoke(nameof(setEqualButtonWhite), (float)0.2);
            }
        }
        catch (System.Exception)
        {
            currentInput = "Error";
            UpdateDisplay();
        }
    }

    IEnumerator DamageCounter()
    {
        damageText.text = $"{currentInput.Length.ToString()} DAMAGE DEALT!!!";

        yield return new WaitForSeconds(3);

        damageText.text = "";
    }
    private void UpdateDisplay()
    {
        displayText.text = currentInput;
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
    private void setEqualButtonWhite()
    {
        equalButton.GetComponent<Image>().color = Color.white;
    }

    //        yield return new WaitForSeconds(3);

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
                button[i].GetComponent<Button>().onClick.AddListener(delegate { buttonClick(text, j); });
            }
        }
    }

    //Delay caller for buttons
    IEnumerator DelayCaller()
    {
        yield return new WaitForSeconds(3);
        questionGeneration();

        //Destroy all button to regenerate all new input
        //destroyAllButton();

        /* Everytime new question generated the button will be regenerate
         * Carry out after 1 second delay
         */
        yield return new WaitForSeconds(1);
        
        buttonGeneration();
        damageCount = 0; //initialize damage counter
    }

    private void questionGeneration()
    {
        question = UnityEngine.Random.Range(0, 10); // generate question [0,10]
        equalButtonText.text = ("= " + question.ToString());
    }

    private void destroyAllButton()
    {
        for (int i = 0; i < button.Length; i++)
        {
                // deactivation of button
                button[i].SetActive(false);
        }

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
    private void ClearInput(Boolean isButton)
    {
        currentInput = "";
        result = 0.0;
        UpdateDisplay();

        if (isButton) 
        {
            for (int i = 0; i < button.Length; i++)
            {
                if (!buttonState[i])
                {
                    buttonState[i] = true;
                    setWhite(i);

                    if (textPosition[i] != 0)
                    {
                        textPosition[i] = 0;
                    }
                }
            }
        }

        else
        {

        }
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
    }