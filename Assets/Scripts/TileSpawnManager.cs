using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManager : MonoBehaviour
{
    public GameObject currentTile;
    public GameObject[] tilePrefabs;    
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(rightTile, currentTile.transform.GetChild(1).position, Quaternion.identity);
        for (int i = 0; i < 10; i++)
        {
            int randomValue = Random.Range(0, 2);

            currentTile = Instantiate(tilePrefabs[randomValue], currentTile.transform.GetChild(randomValue).position, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
                Destroy(gameObject);        
        }
    }

}
