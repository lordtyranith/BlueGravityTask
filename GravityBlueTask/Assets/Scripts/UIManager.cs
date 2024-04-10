using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>   
{
    [Header("Stores")]
    [SerializeField] SellerShop shopWindow;
    [SerializeField] BuyerShop buyerStore;

    [Header("Player Settings")]
    public InventorySystem inventoryWindow;
    public TextMeshProUGUI money;

    [Header("Screen Buttons")]
    [SerializeField] Button inventoryButton;

    [Header("Events")]
    [SerializeField] AlertPopUp alert;


    public void OpenShopWindow(clotheType type)
    {
        shopWindow.gameObject.SetActive(true);
        shopWindow.CallItemSeller(type);
    }
    public void OpenBuyerShop()
    {
        buyerStore.gameObject.SetActive(true);
        buyerStore.CallItemBuyer();  // If we need the buyer to purchase specific item types, we can select the types here, just sending the types
    }
    public void StartingUI()
    {
        money.text = PlayerSettings.Instance.currentMoney.ToString();

        inventoryButton.onClick.RemoveAllListeners();
        inventoryButton.onClick.AddListener(() => inventoryWindow.gameObject.SetActive(true));
        inventoryButton.onClick.AddListener(() => inventoryWindow.OpeningInventory());

        // music button


    }
    public void CloseAllShops()
    {
        shopWindow.gameObject.SetActive(false);
        buyerStore.gameObject.SetActive(false);
    }

    public void CallAlert(string message)
    {
        alert.gameObject.SetActive(true);
        CloseAllShops();
        alert.CallAlertBox(message);   

    }
}
