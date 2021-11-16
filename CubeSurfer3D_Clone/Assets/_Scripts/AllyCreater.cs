using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCreater : ACreater
{
    [field: SerializeField] public int columnCount { get; private set; }
    public override void CreateFixed(GameObject go, int _columnCount, int lineCount)
    {
        columnCount = _columnCount;
        base.CreateFixed(go,columnCount, lineCount);
    }
}
