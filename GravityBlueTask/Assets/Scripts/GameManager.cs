using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerMoviment playerController;
    public ClothesObjects itemList;

    private void Start()   // Used to start anything on the game. I dont use start function in another scripts, its can cause some conflict in call order
    {
        playerController.ActivatePlayerControl();  // To activate player controller
        UIManager.Instance.StartingUI(); // To activate UI settings
        PlayerSettings.Instance.StartedEquips(); // To equip player with a starter set
    }



}
