using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerNPC : MonoBehaviour
{
    [SerializeField] clotheType type;
    [SerializeField] List<string> msg;





   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ABRIU!");

           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("fechou!");

          
        }
    }


}
