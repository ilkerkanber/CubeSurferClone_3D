using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float VerticalSpeed;
    [SerializeField] float HorizontalSpeed;
    [SerializeField] Bag _bag;

    Mover _mover;
    InputController _inputController;

    float inputValue;
  
    void Awake()
    {
        Physics.gravity = new Vector3(0, -30F, 0);
        _mover = new Mover(this);
        _inputController = new InputController();
    }
    void Update()
    {
        inputValue = _inputController.GetInput();
    }
    void FixedUpdate()
    {
        _mover.Active((HorizontalSpeed * inputValue), VerticalSpeed);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.parent == null)
        {
            return;
        }
        if (collision.collider.transform.parent.TryGetComponent<AllyCreater>(out AllyCreater allyCreater))
        {
            _bag.AddCube(collision.collider.transform.parent.gameObject, allyCreater.count);
        }
    }
}
