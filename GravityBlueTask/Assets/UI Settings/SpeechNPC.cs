using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechNPC : MonoBehaviour
{
    [SerializeField] GameObject box1;
    [SerializeField] TextMeshProUGUI msg;
    [SerializeField] GameObject box2; 
    [SerializeField] GameObject box3; 
    [SerializeField] Button SellerButton; 
    [SerializeField] Button BuyerButton;

    [SerializeField] ScaleEffect MsgSell;
    [SerializeField] ScaleEffect MsgBuy;

    public void CallBoxes(clotheType type, string message)
    {
       
        StartCoroutine(CallingBoxes());
        msg.text = message; 

        SellerButton.onClick.RemoveAllListeners();
        SellerButton.onClick.AddListener(() => SoundManager.Instance.SoundClicking1());
        SellerButton.onClick.AddListener(() => UIManager.Instance.OpenShopWindow(type));
        SellerButton.onClick.AddListener(() => CloseBoxes());
        SellerButton.onClick.AddListener(() => this.gameObject.SetActive(false));

        BuyerButton.onClick.RemoveAllListeners();
        BuyerButton.onClick.AddListener(() => SoundManager.Instance.SoundClicking1());
        BuyerButton.onClick.AddListener(() => UIManager.Instance.OpenBuyerShop());
        BuyerButton.onClick.AddListener(() => CloseBoxes());
        BuyerButton.onClick.AddListener(() => this.gameObject.SetActive(false));
    }

    IEnumerator CallingBoxes()
    {
        box1.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        box2.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        box3.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        MsgSell.CallScaleEffect();
        MsgBuy.CallScaleEffect();
    }

    public void CloseBoxes()
    {
        box1.SetActive(false);
        box2.SetActive(false);
        box3.SetActive(false);
    }



}
