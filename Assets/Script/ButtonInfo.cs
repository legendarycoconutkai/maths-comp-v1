using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    // Create a Dictionary to store strings and their corresponding boolean values
    Dictionary<string, bool> operators = new Dictionary<string, bool>()
    {
    // Add elements to the dictionary
    {"+", true},
    {"-", true},
    {"*", true},
    {"/", true},
    {"0", true},
    {"1", true},
    {"2", true},
    {"3", true},
    {"4", true},
    {"5", true},
    {"6", true},
    {"7", true},
    {"8", true},
    {"9", true},
    {"0", true},
    {"!", false},
    {"^2", true},
    {"sqrt", true}
    };
}
