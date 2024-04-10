using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlertPopUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;
    public Button OkButton;


    public void CallAlertBox(string alertText)
    {
        textBox.text = alertText;
        OkButton.onClick.RemoveAllListeners();
        OkButton.onClick.AddListener(() => this.gameObject.SetActive(false));   
    }
}
