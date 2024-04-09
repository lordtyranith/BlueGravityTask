using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : Singleton<PlayerSettings>
{
    [Header("Player Money")]
    [SerializeField] float currentMoney;

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

    public void EquippingItem(Clothes item)
    {
        switch (item.part)
        {
            case clotheType.Hood:
                AddingItemToInventory(HoodPart);
                HoodPart = item;
                RemovingInventoryItem(item);
                HoodSprite.sprite = item.ingameImage;
                break;

            case clotheType.Legs:
                AddingItemToInventory(LegsPart);
                LegsPart = item;
                RemovingInventoryItem(item);
                LegsSprite.sprite = item.ingameImage;

                break;

            case clotheType.Body:
                AddingItemToInventory(BodyPart);
                BodyPart = item;
                RemovingInventoryItem(item);
                BodySprite.sprite = item.ingameImage;

                break;
        }
        // update the ui of inventory and character


    }

    public void ChangingCurrentMoney(float value)
    {
        currentMoney = currentMoney + value; 
    }


}
