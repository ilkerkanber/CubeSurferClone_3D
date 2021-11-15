using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACreater : MonoBehaviour
{
    public GameObject cubePrefab;
    public virtual void CreateFixed(GameObject go, int columnCount, int lineCount)
    {
        Vector3 pos = transform.position;
        Vector3 linePos = transform.position;
        for (int i = 1; i <= lineCount; i++)
        {
            GameObject lineObject = CreateFreeLine(go, i, linePos);

            CreateColumn(lineObject, columnCount, pos, linePos);

            linePos += Vector3.right;
            pos = transform.position;
        }
    }
    public virtual void CreateRandom(GameObject go, int MinColumn, int MaxColumn, int lineCount)
    {
        Vector3 pos = transform.position;
        Vector3 linePos = transform.position;
        for (int i = 1; i <= lineCount; i++)
        {
            GameObject lineObject = CreateFreeLine(go,i, linePos);

            int randomNumber = Random.Range(MinColumn, MaxColumn+1);
            CreateColumn(lineObject, randomNumber, pos, linePos);

            linePos += Vector3.right;
            pos = transform.position;
        }
    }
    void CreateColumn(GameObject lineObject, int columnCount, Vector3 pos, Vector3 linePos)
    {
        for (int z = 1; z <= columnCount; z++)
        {
            GameObject gObject = Instantiate(cubePrefab, linePos, transform.rotation);
            gObject.transform.parent = lineObject.transform;
            gObject.transform.position = new Vector3(linePos.x, pos.y, transform.position.z);
            pos += Vector3.up;
        }
    }
    GameObject CreateFreeLine(GameObject go, int index,Vector3 pos)
    {
        GameObject newObject = new GameObject();
        newObject.transform.parent = go.transform;
        newObject.name = "Line" + index;
        newObject.transform.position = pos;
        return newObject;
    }
}
