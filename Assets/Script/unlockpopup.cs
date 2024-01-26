using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class unlockpopup : MonoBehaviour
{
    public TextMeshProUGUI UnlockTitle;
    public TextMeshProUGUI OperatorName;
    public TextMeshProUGUI OperatorDesc;
    public Image OperatorImage;
    public Button CloseButton;
    public GameObject unlockWindow;

    void Update()
    {
        // Check for the 'U' key press
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Call the ShowPopup method with your desired information
            // ShowPopup("New Accessory Unlocked!", "Accessory Name", "Description of the accessory.", OperatorImage);
            ShowPopupTest();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            // Call the ShowPopup method with your desired information
            ClosePopup();
        }
    }

    private void ShowPopup(string v1, string v2, string v3, Image operatorImage)
    {
        throw new NotImplementedException();
    }

    public void ShowPopup(string title, string name, string description, Sprite accessorySprite)
    {
        UnlockTitle.text = title;
        OperatorName.text = name;
        OperatorDesc.text = description;
        OperatorImage.sprite = accessorySprite;

        unlockWindow.SetActive(true);
    }
    public void ShowPopupTest()
    {
        if (!unlockWindow.activeSelf)
        {
            unlockWindow.SetActive(true);
        }
    }

    public void ClosePopup()
    {
        if (unlockWindow.activeSelf)
        {
            unlockWindow.SetActive(false);
        }
    }
}
