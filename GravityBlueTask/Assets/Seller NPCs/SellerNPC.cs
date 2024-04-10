using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerNPC : MonoBehaviour
{
    [SerializeField] clotheType type;
    [SerializeField] List<string> msgs;
    [SerializeField] string msg;
    [SerializeField] SpeechNPC boxMsg;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boxMsg.gameObject.SetActive(true);
            boxMsg.CallBoxes(type, msg);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boxMsg.CloseBoxes();
            boxMsg.gameObject.SetActive(false);
            UIManager.Instance.CloseAllShops();
        }
    }


}
