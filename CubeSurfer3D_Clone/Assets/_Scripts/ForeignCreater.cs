using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeignCreater : ACreater
{
    [field: SerializeField] public int columnCount { get; private set; }
    [field: SerializeField] public int lineCount { get; private set; }

    public override void CreateFixed(GameObject go, int columnCount, int lineCount)
    {
        base.CreateFixed(go, columnCount, lineCount);
    }
    public override void CreateRandom(GameObject go, int MinColumn, int MaxColumn, int lineCount)
    {
        base.CreateRandom(go,MinColumn, MaxColumn, lineCount);
    }
}
