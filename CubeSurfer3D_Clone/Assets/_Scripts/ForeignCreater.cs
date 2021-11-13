using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeignCreater : ACreater
{
    [field:SerializeField] public int count { get; private set; }
    public bool IsCollision { get; set; }
    [SerializeField] GameObject go;
 
    void Start()
    {
        Create(go,count);   
    }
    public override void Create(GameObject go, int count)
    {
        base.Create(go,count);
    }
}
