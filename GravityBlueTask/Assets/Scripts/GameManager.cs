using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerMoviment playerController;
    public ClothesObjects itemList;

    private void Start()
    {
        playerController.ActivatePlayerControl();  // To activate player controller
    }



}
