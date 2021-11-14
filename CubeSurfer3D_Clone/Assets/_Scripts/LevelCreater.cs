using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreater : MonoBehaviour
{
    [SerializeField] GameObject player;
    [Header("ROAD OPTIONS")]
    [SerializeField] GameObject road;
    [Space]
    [Header("OBJECT OPTIONS")]
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] List<GameObject> collectables;

    GameObject parent;
    void Start()
    {
        CreateParent();
        CreateRoad(10);
        CreatePlayer();
    }
    void CreatePlayer()
    {
        Instantiate(player, Vector3.zero, player.transform.rotation,parent.transform);
    }
    void CreateParent()
    {
        parent = new GameObject();
        parent.name = "LEVEL";
        parent.tag = "LEVEL";
    }
    void CreateRoad(int length)
    {
        Vector3 newScale = new Vector3(0.5f, 1, length);
        road.transform.localScale = newScale;
        Instantiate(road, road.transform.position, road.transform.rotation, parent.transform);
    }
}
