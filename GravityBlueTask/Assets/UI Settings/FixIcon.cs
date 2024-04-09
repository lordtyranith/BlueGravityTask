using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixIcon : MonoBehaviour
{
    //This partition would not be necessary if it had a centered icon and the correct size. It was just made to maintain a bug-free appearance


    [SerializeField] GameObject HoodItem;
    [SerializeField] GameObject LegsItem;
    [SerializeField] GameObject BodyItem;
    public Button buttonIcon;

    [SerializeField] Sprite UnequippedHood;
    [SerializeField] Sprite UnequippedLegs;
    [SerializeField] Sprite UnequippedBody;

    public void CallIconSlot(Clothes item)
    {
        HoodItem.SetActive(false);
        LegsItem.SetActive(false);
        BodyItem.SetActive(false);



        switch (item.part)
        {
            case clotheType.Hood:
                HoodItem.SetActive(true);
                HoodItem.transform.GetComponent<Image>().sprite = item.iconImage;
                break;


            case clotheType.Legs:
                LegsItem.SetActive(true);
                LegsItem.transform.GetComponent<Image>().sprite = item.iconImage;
                break;

            case clotheType.Body:
                BodyItem.SetActive(true);
                BodyItem.transform.GetComponent<Image>().sprite = item.iconImage;
                break;

            default:
                HoodItem.SetActive(false);
                LegsItem.SetActive(false);
                BodyItem.SetActive(false);
                break;
        }
    }



    public void EquipingItens(Clothes item)
    {
        switch (item.part)
        {
            case clotheType.Hood:
                HoodItem.transform.GetComponent<Image>().sprite = item.iconImage;
                Color colorImage = HoodItem.transform.GetComponent<Image>().color;
                colorImage.a = 1f;
                HoodItem.transform.GetComponent<Image>().color = colorImage;
                break;

            case clotheType.Legs:
                LegsItem.transform.GetComponent<Image>().sprite = item.iconImage;
                Color colorImage1 = LegsItem.transform.GetComponent<Image>().color;
                colorImage1.a = 1f;
                LegsItem.transform.GetComponent<Image>().color = colorImage1;
                break;

            case clotheType.Body:
                BodyItem.transform.GetComponent<Image>().sprite = item.iconImage;
                Color colorImage2 = BodyItem.transform.GetComponent<Image>().color;
                colorImage2.a = 1f;
                BodyItem.transform.GetComponent<Image>().color = colorImage2;
                break;

        }
    }


}
