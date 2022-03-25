using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileSpawnManager : MonoBehaviour
{
    public GameObject currentTile;
    public GameObject[] tilePrefabs;
    private static TileSpawnManager instance;
    Stack<GameObject> rightTile = new Stack<GameObject>();
    Stack<GameObject> forwardTile = new Stack<GameObject>();

    //public static TileSpawnManager Instance { get => instance;}

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
      
    //}

    public static TileSpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileSpawnManager>(); ;
            }
            return instance;

        }
    }
        // Start is called before the first frame update
    void Start()
    {
        //Instantiate(rightTile, currentTile.transform.GetChild(1).position, Quaternion.identity);
        //for (int i = 0; i < 10; i++)
        //{
        //    //SpawnTile();
        //    CreateTile();

        //}

        //SpawnTile();
    }

    public void SpawnTile()
    {
        /*int indexNumber = Random.Range(0,10);
        if (indexNumber == 3)
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }*/
        
        if ((rightTile.Count == 0) && (forwardTile.Count == 0))
        {
            CreateTile(20);
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
          GameObject temp =  forwardTile.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(Random.Range(0,2)).position;
            currentTile = temp;
        }
        else if (randomValue == 1)
        {
            GameObject temp = rightTile.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(Random.Range(0,2)).position;
            currentTile = temp;
        }
       

    }


    public void CreateTile(int value)
    {
        for (int i = 0; i < value; i++)
        {
            //SpawnTile();
            //CreateTile();
            rightTile.Push(Instantiate(tilePrefabs[1]));
            tilePrefabs[1].SetActive(false);
            forwardTile.Push(Instantiate(tilePrefabs[0]));
            tilePrefabs[0].SetActive(false);

        }
    }

    public void BackToRightPool(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        rightTile.Push(obj);
        rightTile.Peek().SetActive(false);
       // obj.SetActive(false);
    } 
    
    public void BackToForwardPool(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        forwardTile.Push(obj);
        forwardTile.Peek().SetActive(false);
        //obj.SetActive(false);
    }
}
