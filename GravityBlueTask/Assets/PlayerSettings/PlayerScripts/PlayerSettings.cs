using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : Singleton<PlayerSettings>
{
    [Header("Player Money")]
    public float currentMoney;

    [Header("Player Inventory")]
    public List<Clothes> itensOnInventory = new List<Clothes>();

    [Header("Player Equipped Itens")]
    public Clothes HoodPart;
    public Clothes BodyPart;
    public Clothes LegsPart;

    [Header("Equipped Itens Sprite")]
    public SpriteRenderer HoodSprite;
    public SpriteRenderer BodySprite;
    public SpriteRenderer LegsSprite;

    public void AddingItemToInventory(Clothes item)
    {
        itensOnInventory.Add(item);
    }

    public void RemovingInventoryItem(Clothes item)
    {
        itensOnInventory.Remove(item);
    }

    public void StartedEquips()
    {
        UIManager.Instance.inventoryWindow.StartedEquips(GameManager.Instance.itemList.GetItensForCategory(clotheType.Hood)[0]);
        UIManager.Instance.inventoryWindow.StartedEquips(GameManager.Instance.itemList.GetItensForCategory(clotheType.Legs)[0]);
        UIManager.Instance.inventoryWindow.StartedEquips(GameManager.Instance.itemList.GetItensForCategory(clotheType.Body)[0]);
    }


    public void ChangingCurrentMoney(float value)
    {
        currentMoney = currentMoney + value; 
        UIManager.Instance.money.text = currentMoney.ToString(); 
    }


}
