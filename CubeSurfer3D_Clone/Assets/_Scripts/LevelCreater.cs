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
    [SerializeField] GameObject allyCreaterPrefab;
    [SerializeField] GameObject foreignCreaterPrefab;

    GameObject root;
    GameObject createrParent;
    int startPoint = 15;
    int allyCount=0;
    int foreignCount=0;
    void Start()
    {
        CreateParents();
        CreateRoad(GameManager.Instance.CurrentLevel * 10);
        CreatePlayer();
        CreateLevel();
    }
    void CreatePlayer()
    {
        Instantiate(player, Vector3.zero, player.transform.rotation,root.transform);
    }
    void CreateParents()
    {
        root = new GameObject();
        root.name = "LEVEL";
        root.tag = "LEVEL";
        createrParent = new GameObject();
        createrParent.name = "Creaters";
        createrParent.transform.parent = root.transform;
    }
    void CreateRoad(int length)
    {
        Vector3 newScale = new Vector3(0.5f, 1, length);
        road.transform.localScale = newScale;
        Instantiate(road, road.transform.position, road.transform.rotation, root.transform);
    }
    void CreateLevel()
    {
        for (int i = startPoint; i < (GameManager.Instance.CurrentLevel * 100); i+=5)
        {
            if (allyCount == foreignCount)
            {
                CreateAlly(i);
            }
            else
            {
                switch (GetRandom(1, 2))
                {
                    case 1:
                        CreateAlly(i);
                        break;
                    case 2:
                        CreateForeign(i);
                        break;
                }
            }
        }
    }
    void CreateAlly(int posZ)
    {
        if (GetRandom(0, 100) >= 50)
        {
            int createdCount = GetRandom(0, 5);
            
            if (createdCount == 0)
            {
                return;
            }
            GameObject newAllyGo = Instantiate(allyCreaterPrefab, new Vector3(GetRandom(-2f, 2f), 0, posZ), transform.rotation, createrParent.transform);
            AllyCreater newAlly = newAllyGo.GetComponent<AllyCreater>();
            newAlly.CreateFixed(newAllyGo, createdCount, 1);
            allyCount += createdCount;
        }
    }
    void CreateForeign(int posZ)
    {
        if (GetRandom(0, 100) >= 50)
        {
            int createdCount = GetRandom(0, (allyCount-foreignCount)-1);
            createdCount = Mathf.Clamp(createdCount, 0, 5);
            
            if (createdCount == 0)
            {
                return;
            }
            GameObject newForeignGo = Instantiate(foreignCreaterPrefab, new Vector3(-2f, 0, posZ), transform.rotation, createrParent.transform);
            ForeignCreater newForeign= newForeignGo.GetComponent<ForeignCreater>();

            switch (GetRandom(1, 2))
            {
                case 1:
                    newForeign.CreateFixed(newForeignGo, createdCount, 5);
                    break;
                case 2:
                    newForeign.CreateRandom(newForeignGo, 0, createdCount, 5);
                    break;
            }
            foreignCount += createdCount;
        }
    }
    int GetRandom(int min,int max)
    {
        return Random.Range(min, max+1); 
    }
    float GetRandom(float min,float max)
    {
        return Random.Range(min, max); ;
    }
}
