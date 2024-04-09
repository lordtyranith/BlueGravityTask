using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>   
{
    [SerializeField] SellerShop shopWindow;
    [SerializeField] InventorySystem inventoryWindow;
    //[SerializeField] SellerShop shopPopUp;




    public void OpenShopWindow(clotheType type)
    {
        shopWindow.gameObject.SetActive(true);
        shopWindow.CallItemSeller(type);
    }
}
