using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover 
{
    PlayerController _playerController;
    Rigidbody rb;

    public Mover(PlayerController playerController)
    {
        rb = playerController.GetComponent<Rigidbody>();
        _playerController = playerController;
    }

    public void Active(float horizontalSpeed, float verticalSpeed)
    {
        rb.velocity = new Vector3(verticalSpeed * Time.deltaTime, 0, horizontalSpeed * Time.deltaTime);
    }
}
