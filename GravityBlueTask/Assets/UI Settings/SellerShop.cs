using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellerShop : MonoBehaviour
{
    [Header("Display")]
    [SerializeField] FixIcon SelectedItemSquare;
    [SerializeField] TextMeshProUGUI nameItem;
    [SerializeField] TextMeshProUGUI priceItem;

    [Header("References and Buttons")]
    [SerializeField] List<FixIcon> FixIconList = new List<FixIcon>();
    Clothes SelectedItem;
    [SerializeField] Button BuyItem;
    [SerializeField] Button closeSeller;

    public void CallItemSeller(clotheType type)
    {
        BuyItem.interactable = false;
        SelectedItemSquare.gameObject.SetActive(false);

        closeSeller.onClick.RemoveAllListeners();
        closeSeller.onClick.AddListener(() => SoundManager.Instance.SoundClicking2());
        closeSeller.onClick.AddListener(() => UIManager.Instance.CloseAllShops());
        nameItem.text = "ITEM";
        priceItem.text = "0";

        foreach (FixIcon item in FixIconList)
        {
            item.gameObject.SetActive(false);
        }

        
        List<Clothes> itemListToSell = GameManager.Instance.itemList.GetItensForCategory(type);  

        int index = 0;

        foreach(Clothes item in itemListToSell)    
        {
            // Get the store with items described in the scriptable object and send it to the list of items of that type

            FixIconList[index].gameObject.SetActive(true);  
            FixIconList[index].CallIconSlot(item);
            FixIconList[index].buttonIcon.onClick.RemoveAllListeners();
            FixIconList[index].buttonIcon.onClick.AddListener(() => SoundManager.Instance.SoundClicking1());
            FixIconList[index].buttonIcon.onClick.AddListener(() => SelectingItemOnShop(item));
            index++;
        }
    }


    public void SelectingItemOnShop(Clothes item)  
    {
        BuyItem.interactable = true;
        SelectedItemSquare.gameObject.SetActive(true);

        SelectedItemSquare.CallIconSlot(item);
        nameItem.text = item.name;
        priceItem.text = item.sellingPrice.ToString();

        BuyItem.onClick.RemoveAllListeners();
        BuyItem.onClick.AddListener(() => SoundManager.Instance.SoundClicking1());
        BuyItem.onClick.AddListener(() => BuyingItem(item));

    }

    public void BuyingItem(Clothes item)
    {   
        if (item.buyingPrice > PlayerSettings.Instance.currentMoney)
        {
            UIManager.Instance.CallAlert("You don't have the money to make this purchase");
        }
        else
        {
           PlayerSettings.Instance.AddingItemToInventory(item);
           PlayerSettings.Instance.ChangingCurrentMoney(-item.sellingPrice);
        }
    }



}
