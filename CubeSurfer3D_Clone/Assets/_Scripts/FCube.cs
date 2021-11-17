using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCube : MonoBehaviour
{
    GameObject trash;
    void Start()
    {
        FindTrasher();
    }
    void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<FCube>())
        {
            return;
        }
        if (hit.transform.parent == null)
        {
            return;
        }
        if (hit.transform.parent.GetComponent<Bag>())
        {
            hit.transform.parent.GetComponent<Bag>().RemoveCube();
            FindTrasher();
            GameObject go = hit.gameObject;
            go.transform.parent = trash.transform;
        }
    }
    void FindTrasher()
    {
        if (trash == null)
        {
            trash = GameObject.FindGameObjectWithTag("Trasher");
        }
    }

}
