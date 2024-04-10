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
    [SerializeField] Button soundButton;

    [Header("Events")]
    [SerializeField] AlertPopUp alert;

    [Header("Animations and Sounds")]
    [SerializeField] ScaleEffect coin;
    [SerializeField] GameObject iconXSound;
     public bool SoundOn = true;

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
        inventoryButton.onClick.AddListener(() => SoundManager.Instance.SoundClicking1());
        inventoryButton.onClick.AddListener(() => inventoryWindow.gameObject.SetActive(true));
        inventoryButton.onClick.AddListener(() => inventoryWindow.OpeningInventory());

        soundButton.onClick.RemoveAllListeners();
        soundButton.onClick.AddListener(() => SoundManager.Instance.MuteAndUnmuteAll(!SoundOn));
        soundButton.onClick.AddListener(() => iconXSound.SetActive(SoundOn));

        coin.CallScaleEffect();
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
