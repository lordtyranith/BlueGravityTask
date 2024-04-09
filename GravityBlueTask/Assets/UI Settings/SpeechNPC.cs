using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechNPC : MonoBehaviour
{
    [SerializeField] GameObject box1;
    [SerializeField] GameObject box2; 
    [SerializeField] Button SellerButton; 
    [SerializeField] Button BuyerButton; 




    public void CallBoxes(clotheType type)
    {
       
        StartCoroutine(CallingBoxes());

        SellerButton.onClick.RemoveAllListeners();
        SellerButton.onClick.AddListener(() => UIManager.Instance.OpenShopWindow(type));
        SellerButton.onClick.AddListener(() => CloseBoxes());
        SellerButton.onClick.AddListener(() => this.gameObject.SetActive(false));

        BuyerButton.onClick.RemoveAllListeners();
        BuyerButton.onClick.AddListener(() => UIManager.Instance.OpenBuyerShop());
        BuyerButton.onClick.AddListener(() => CloseBoxes());
        BuyerButton.onClick.AddListener(() => this.gameObject.SetActive(false));
    }

    IEnumerator CallingBoxes()
    {
        box1.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        box2.SetActive(true);
    }

    public void CloseBoxes()
    {
        box1.SetActive(false);
        box2.SetActive(false);
    }
}
