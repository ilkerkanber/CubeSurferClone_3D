using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreater : MonoBehaviour
{
    [Header("ROAD OPTIONS")]
    [SerializeField] GameObject road;
    [SerializeField] Transform roadParentObject;
    [Space]
    [Header("OBJECT OPTIONS")]
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] List<GameObject> collectables;

    void Awake()
    {
        CreateLevel();
    }
    void CreateRoad(int length)
    {
        Vector3 newScale = new Vector3(0.5f, 1, length);
        road.transform.localScale = newScale;
        Instantiate(road, road.transform.position, road.transform.rotation, roadParentObject);
    }
    public void CreateLevel()
    {
        CreateRoad(10);
    }
}
