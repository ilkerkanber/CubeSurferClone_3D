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
    float bugTimer;
    void OnEnable()
    {
        GameManager.OnLostLevel += FreezePlayer;
        GameManager.OnWinLevel += FreezePlayer;
    }
    void OnDisable()
    {
        GameManager.OnLostLevel -= FreezePlayer;
        GameManager.OnWinLevel -= FreezePlayer;
    }
    void Awake()
    {
        _mover = new Mover(this);
        _inputController = new InputController();
    }
    void Update()
    {
        inputValue = _inputController.GetInput();
        LifeState();
    }
    void FixedUpdate()
    {
        _mover.Active((HorizontalSpeed * inputValue), VerticalSpeed);
    }
    void LifeState()
    {
        if (transform.GetChild(0).childCount <= 0)
        {
            GameManager.Instance.IsLose = true;
        }
    }
    void FreezePlayer()
    {
        VerticalSpeed = 0;
        HorizontalSpeed = 0;
    }
    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Finish"))
        {
            GameManager.Instance.IsWin = true;
        }
        if (Time.time < bugTimer+0.1f)
        {
            return;
        }
        if (hit==null)
        {
            return;
        }
        if (hit.transform.parent.parent.TryGetComponent<AllyCreater>(out AllyCreater allyCreater))
        {
            _bag.AddCube(hit.transform.parent.gameObject, allyCreater.columnCount);
            bugTimer = Time.time;
        }
    }
   
}
