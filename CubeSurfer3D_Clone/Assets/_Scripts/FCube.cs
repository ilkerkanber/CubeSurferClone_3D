using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCube : MonoBehaviour
{
    RaycastHit hit;
    void FixedUpdate()
    {
        CollisionControl(new Vector3(0.49f, 0, -0.6f));//LEFT
        CollisionControl(new Vector3(-0.49f, 0, -0.6f));//RIGHT
    }
    void CollisionControl(Vector3 pos)
    {
        if (Physics.Raycast(transform.position + pos, -Vector3.forward, out hit, 0.1f))
        {
            if (hit.collider.GetComponent<FCube>())
            {
                return;
            }
            if (hit.collider.transform.parent.GetComponent<Bag>())
            {
                GameObject go = hit.collider.gameObject;
                go.transform.parent = null;
            }
        }
    }

}
