using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float VerticalSpeed;
    [SerializeField] float HorizontalSpeed;
    [SerializeField] Bag bag;

    Mover _mover;
    InputController _inputController;


    float inputValue;
    float bugTimer;
    void Awake()
    {
        _mover = new Mover(this);
        _inputController = new InputController();
    }
    void Start()
    {

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
        if (Time.time < bugTimer + 0.5f)
        {
            return;
        }
        if (collision.collider.transform.parent.TryGetComponent<ForeignCreater>(out ForeignCreater foreignCreater))
        {
            if (!foreignCreater.IsCollision)
            {
                foreignCreater.IsCollision = true;
                bag.RemoveCube(foreignCreater.count);
            }
        }
        else if(collision.collider.transform.parent.TryGetComponent<AllyCreater>(out AllyCreater allyCreater))
        {
            bag.AddCube(collision.collider.transform.parent.gameObject, allyCreater.count);
        }
        bugTimer = Time.time;

    }
}
