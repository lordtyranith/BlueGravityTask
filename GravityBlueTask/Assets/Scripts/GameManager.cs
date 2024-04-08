using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerMoviment playerController;

    private void Start()
    {
        playerController.ActivatePlayerControl();  // To activate player controller
    }



}
