using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyerShop : MonoBehaviour
{

    [Header("Inventory Itens")]
    [SerializeField] List<FixIcon> inventorySlots = new List<FixIcon>();

    [Header("Display")]
    [SerializeField] FixIcon SelectedItemSquare;
    [SerializeField] TextMeshProUGUI nameItem;
    [SerializeField] TextMeshProUGUI priceItem;

    Clothes SelectedItem;
    [SerializeField] Button SellItem;
    [SerializeField] Button closeBuyer;

    public void CallItemBuer()
    {

    }






}
