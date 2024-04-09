using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>   
{
    [SerializeField] SellerShop shopWindow;
    [SerializeField] BuyerShop buyerStore;
    public InventorySystem inventoryWindow;
    public TextMeshProUGUI money;
    [SerializeField] Button inventoryButton;


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

        // inventory button
        // music button


    }

}
