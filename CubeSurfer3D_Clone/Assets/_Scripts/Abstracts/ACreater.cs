using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACreater : MonoBehaviour
{
   public virtual void Create(GameObject go, int columnCount,int lineCount)
    {
        Vector3 pos = transform.position;
        Vector3 linePos = transform.position;
        for (int i = 1; i <= lineCount; i++)
        {
           GameObject lineObject= CreateFreeLine(i,linePos);
            for (int z= 1; z <= columnCount; z++)
            {
                GameObject gObject = Instantiate(go, linePos, transform.rotation);
                gObject.transform.parent = lineObject.transform;
                gObject.transform.position = pos + new Vector3(linePos.x,0,0);
                pos += Vector3.up;
            }
            linePos += Vector3.right;
            pos = transform.position;
        }
    }
    GameObject CreateFreeLine(int index,Vector3 pos)
    {
        GameObject newObject = new GameObject();
        newObject.transform.parent = transform;
        newObject.name = "Line" + index;
        newObject.transform.position = pos;
        return newObject;
    }
}
