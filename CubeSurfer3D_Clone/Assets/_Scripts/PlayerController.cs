using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float VerticalSpeed;
    [SerializeField] float HorizontalSpeed;

    Mover _mover;
    InputController _inputController;
    void Awake()
    {
        _mover = new Mover(this);
    }
    void FixedUpdate()
    {

        _inputController.GetInput();
    }


}
