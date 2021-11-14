using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCreater : ACreater
{
    [field: SerializeField] public int columnCount { get; private set; }

    [SerializeField] GameObject go;
    void Start()
    {
        Create(go, columnCount, 1);    
    }
    public override void Create(GameObject go, int columnCount, int lineCount)
    {
        base.Create(go, columnCount, lineCount);
    }

}
