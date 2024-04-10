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

    public void CallItemBuyer()
    {
        SelectedItemSquare.gameObject.SetActive(false);
        nameItem.text = "ITEM";
        priceItem.text = "0";
        closeBuyer.onClick.RemoveAllListeners();
        closeBuyer.onClick.AddListener(() => SoundManager.Instance.SoundClicking2());
        closeBuyer.onClick.AddListener(() => UIManager.Instance.CloseAllShops());
        UpdateInventorySquare();
    }

    public void UpdateInventorySquare()
    {
        foreach (FixIcon slot in inventorySlots)
        {
            slot.buttonIcon.interactable = false;
            slot.gameObject.SetActive(false);
        }

        int index = 0;
        foreach (Clothes item in PlayerSettings.Instance.itensOnInventory)
        {
            inventorySlots[index].gameObject.SetActive(true);
            inventorySlots[index].buttonIcon.interactable = true;
            inventorySlots[index].CallIconSlot(item);
            inventorySlots[index].buttonIcon.onClick.RemoveAllListeners();
            inventorySlots[index].buttonIcon.onClick.AddListener(() => SoundManager.Instance.SoundClicking1());
            inventorySlots[index].buttonIcon.onClick.AddListener(() => SelectingItemOnShop(item));

            index++;
        }
    }
    public void SelectingItemOnShop(Clothes item) 
    {
        SellItem.interactable = true;
        SelectedItemSquare.gameObject.SetActive(true);
        SelectedItemSquare.CallIconSlot(item);
        nameItem.text = item.name;
        priceItem.text = item.buyingPrice.ToString();

        SellItem.onClick.RemoveAllListeners();
        SellItem.onClick.AddListener(() => SoundManager.Instance.SoundClicking1());
        SellItem.onClick.AddListener(() => SellingItem(item));

    }


    public void SellingItem(Clothes item)
    {
        PlayerSettings.Instance.RemovingInventoryItem(item);
        PlayerSettings.Instance.ChangingCurrentMoney(item.buyingPrice);
        UpdateInventorySquare();
        SellItem.interactable = false;
        nameItem.text = "ITEM";
        priceItem.text = "0";
        SelectedItemSquare.RemoveItemSlot();
    }

}
