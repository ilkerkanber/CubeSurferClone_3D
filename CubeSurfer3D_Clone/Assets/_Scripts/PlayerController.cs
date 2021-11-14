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
        CollisionEnter(new Vector3(-0.49f, 0, 0.6f));
        CollisionEnter(new Vector3(0.49f, 0, 0.6f));
    }
    void CollisionEnter(Vector3 pos)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + pos, Vector3.forward, out hit, 0.1f))
        {
            if (hit.collider.transform.parent.parent.TryGetComponent<AllyCreater>(out AllyCreater allyCreater))
            {
                _bag.AddCube(hit.collider.transform.parent.gameObject, allyCreater.columnCount);
            }
        }
    }

}
