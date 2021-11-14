using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeignCreater : ACreater
{
    [field: SerializeField] public int columnCount { get; private set; }
    [field: SerializeField] public int lineCount { get; private set; }

    [SerializeField] GameObject go;
    void Start()
    {
        Create(go, columnCount, lineCount);
    }
    public override void Create(GameObject go, int columnCount, int lineCount)
    {
        base.Create(go, columnCount, lineCount);
    }
}
