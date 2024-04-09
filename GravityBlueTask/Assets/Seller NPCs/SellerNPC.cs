using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerNPC : MonoBehaviour
{
    [SerializeField] clotheType type;
    [SerializeField] List<string> msg;
    [SerializeField] SpeechNPC boxMsg;

    




   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ABRIU!");
            boxMsg.gameObject.SetActive(true);
            boxMsg.CallBoxes(type);


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("fechou!");
            boxMsg.CloseBoxes();
            boxMsg.gameObject.SetActive(false);



        }
    }


}
