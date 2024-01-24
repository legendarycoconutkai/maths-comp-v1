using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.UI;
using TMPro;

public class buttonTesting : MonoBehaviour
{
    public GameObject button;
    public TextMeshProUGUI buttonText;
    string[] operators = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "^" };

    private void OnEnable()
    {
        button.SetActive(true);
        string text = operators[Random.Range(0, operators.Length)];
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = text;
    }
}