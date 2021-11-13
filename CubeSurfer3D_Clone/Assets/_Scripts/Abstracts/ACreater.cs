using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACreater : MonoBehaviour
{
   public virtual void Create(GameObject go, int count)
    {
        Vector3 pos = transform.position;
        for (int i = 1; i <= count; i++)
        {
            GameObject gObject = Instantiate(go, pos, transform.rotation);
            gObject.transform.parent = transform;
            pos += Vector3.up;
        }
    }
}
