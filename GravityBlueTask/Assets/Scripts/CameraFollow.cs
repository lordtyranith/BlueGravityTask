using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerLocation;


    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, playerLocation.position, 0.1f);
    }
}
