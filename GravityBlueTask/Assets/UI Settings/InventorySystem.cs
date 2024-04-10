using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [Header("Equipped Itens")]
    [SerializeField] FixIcon HoodEquipped;
    [SerializeField] FixIcon BodyEquipped;
    [SerializeField] FixIcon LegsEquipped;

    [Header("Inventory Itens")]
    [SerializeField] List<FixIcon> inventorySlots = new List<FixIcon>();

    [Header("Character Custom")]
    [SerializeField] Image HoodEquippedChar;
    [SerializeField] Image BodyEquippedChar;
    [SerializeField] Image LegsEquippedChar;


    [SerializeField] Button closeInventoryButton;


    public void OpeningInventory()
    {
        closeInventoryButton.onClick.RemoveAllListeners();
        closeInventoryButton.onClick.AddListener(() => SoundManager.Instance.SoundClicking2());   
        closeInventoryButton.onClick.AddListener(() => this.gameObject.SetActive(false));   

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
            inventorySlots[index].buttonIcon.onClick.AddListener(() => EquippingItens(item));

            index++;
        }
    }

    public void StartedEquips(Clothes item)
    {
        switch (item.part)
        {
            case clotheType.Hood:          
                HoodEquipped.EquipingItens(item);
                HoodEquippedChar.sprite = item.ingameImage;
                PlayerSettings.Instance.HoodPart = item;
                PlayerSettings.Instance.HoodSprite.sprite = item.ingameImage;
                break;

            case clotheType.Legs:         
                LegsEquipped.EquipingItens(item);
                LegsEquippedChar.sprite = item.ingameImage;
                PlayerSettings.Instance.LegsPart = item;
                PlayerSettings.Instance.LegsSprite.sprite = item.ingameImage;
                break;

            case clotheType.Body:                
                BodyEquipped.EquipingItens(item);
                BodyEquippedChar.sprite = item.ingameImage;
                PlayerSettings.Instance.BodyPart = item;
                PlayerSettings.Instance.BodySprite.sprite = item.ingameImage;

                break;
        }
        UpdateInventorySquare();
    }
    public void EquippingItens(Clothes item)
    {
        Clothes equippedItem;

        switch (item.part)
        {
            case clotheType.Hood:

                if(PlayerSettings.Instance.HoodPart != null)
                {
                    equippedItem = PlayerSettings.Instance.HoodPart;
                    PlayerSettings.Instance.AddingItemToInventory(equippedItem);
                }
                HoodEquipped.EquipingItens(item);
                HoodEquippedChar.sprite = item.ingameImage;
                PlayerSettings.Instance.HoodPart = item;
                PlayerSettings.Instance.HoodSprite.sprite = item.ingameImage;
                break;

            case clotheType.Legs:
                if (PlayerSettings.Instance.LegsPart != null)
                {
                    equippedItem = PlayerSettings.Instance.LegsPart;
                    PlayerSettings.Instance.AddingItemToInventory(equippedItem);
                }
                LegsEquipped.EquipingItens(item);
                LegsEquippedChar.sprite = item.ingameImage;
                PlayerSettings.Instance.LegsPart = item;
                PlayerSettings.Instance.LegsSprite.sprite = item.ingameImage;
                break;

            case clotheType.Body:
                if (PlayerSettings.Instance.BodyPart != null)
                {
                    equippedItem = PlayerSettings.Instance.BodyPart;
                    PlayerSettings.Instance.AddingItemToInventory(equippedItem);
                }
                BodyEquipped.EquipingItens(item);
                BodyEquippedChar.sprite = item.ingameImage;
                PlayerSettings.Instance.BodyPart = item;
                PlayerSettings.Instance.BodySprite.sprite = item.ingameImage;
                break;
        }

        PlayerSettings.Instance.RemovingInventoryItem(item);
        UpdateInventorySquare();

    }




}
