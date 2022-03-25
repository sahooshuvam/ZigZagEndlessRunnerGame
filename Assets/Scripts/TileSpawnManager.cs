using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManager : MonoBehaviour
{
    public GameObject currentTile ;
    public GameObject[] tilesPrefab;
    private static TileSpawnManager instance;

    Stack<GameObject> rightTile = new Stack<GameObject>();
    Stack<GameObject> forwardTile = new Stack<GameObject>();
    public static TileSpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileSpawnManager>();
            }
            return instance;
        }
    }
        
    void Start()
    {
        CreateTile(50);
        for (int i = 0; i < 30; i++)
        {
            SpawnTile();

        }
    }


    public void SpawnTile()
    {
        if((rightTile.Count == 0) || (forwardTile.Count == 0))
        {
            CreateTile(20);
        }
        int k = Random.Range(0, 2);
       if(k == 0)
        {
            GameObject temp = forwardTile.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).position;
            currentTile = temp;

        }
        else if(k==1)
        {
            GameObject temp = rightTile.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(1).position;
            currentTile = temp;
        }

    }
       
    public void CreateTile(int value)
    {
        for (int i = 0; i < value; i++)
        {
            rightTile.Push(Instantiate(tilesPrefab[1]));
            tilesPrefab[1].SetActive(false);
            forwardTile.Push(Instantiate(tilesPrefab[0]));
            tilesPrefab[0].SetActive(false);
            rightTile.Peek().name = "RightTile";
            forwardTile.Peek().name = "ForwardTile";

        }
    }
    public void BackToRightPool(GameObject obj)
    {
        rightTile.Push(obj);
        rightTile.Peek().SetActive(false);
    }
    public void BackToForwardPool(GameObject obj)
    {
        forwardTile.Push(obj);
        forwardTile.Peek().SetActive(false);
    }
}
