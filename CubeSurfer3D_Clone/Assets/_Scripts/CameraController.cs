using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    void Update()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerController>().gameObject;
        }
    }
    void LateUpdate()
    {
        WatchTarget();
    }
    void WatchTarget()
    {
        transform.position = new Vector3(0, 0, target.transform.position.z);
    }
}
