using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public List<GameObject> bag;
    void Awake()
    {
        bag = new List<GameObject>();
        bag.Add(transform.GetChild(0).gameObject);
    }
    void Update()
    {
        if (transform.childCount == 0)
        {
            //LOSE
        }
        if (transform.childCount < bag.Count)
        {
            RemoveCube(bag.Count - transform.childCount);
        }    
    }
    public void AddCube(GameObject parent, int count)
    {
        for (int i = 1; i <= count; i++)
        {
            GameObject go = parent.transform.GetChild(0).gameObject;
            Sort();
            go.transform.parent = transform;
            go.transform.position = transform.position;
            bag.Add(go);
        }
    }
    public void RemoveCube(int count)
    {
        for (int i = bag.Count - 1; i >= count; i--)
        {
            bag.RemoveAt(i);
        }
    }
    public void Sort()
    {
        for(int i = 0; i < bag.Count; i++)
        {
            bag[i].transform.position += Vector3.up;
        }
    }
}
