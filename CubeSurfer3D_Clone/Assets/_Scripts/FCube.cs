using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCube : MonoBehaviour
{
    GameObject trash;
    RaycastHit hit;
    void Awake()
    {
        trash = GameObject.FindGameObjectWithTag("TRASH");
    }
    void FixedUpdate()
    {
        CollisionControl(new Vector3(0.40f, 0, -0.6f));
        CollisionControl(new Vector3(-0.40f, 0, -0.6f));
    }
    void CollisionControl(Vector3 pos)
    {
        if (Physics.Raycast(transform.position + pos, -Vector3.forward, out hit, 0.1f))
        {
            if (hit.collider.GetComponent<FCube>())
            {
                return;
            }
            if (hit.collider.transform.parent == null)
            {
                return;
            }
            if (hit.collider.transform.parent.GetComponent<Bag>())
            {
                GameObject go = hit.collider.gameObject;
                go.transform.parent = trash.transform;
            }
        }
    }

}
