using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 direction;
    public float playerSpeed;
    TileSpawnManager tileSpawnManager;
    ScoreManager score;
    public GameObject tempGameObject;

    // Start is called before the first frame update

 
    void Start()
    {
        tileSpawnManager = GameObject.Find("TileSpawnManager").GetComponent<TileSpawnManager>();
        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        for (int i = 0; i < 10; i++)
        {
            TileSpawnManager.Instance.SpawnTile();
        }
    }

    
       

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))           
        {
            //if player moving forward then move him left
            if (direction == Vector3.forward)
            {
                direction = Vector3.left;
            }
            else 
            {
                direction = Vector3.forward;
            }
                
        }
        transform.Translate(direction * playerSpeed * Time.deltaTime);
        
        
    }


   /* private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "RightTile")
        {
            StartCoroutine(RightPool());
            // Destroy(collision.gameObject,2f);
            //TileSpawnManager.Instance.BackToRightPool(collision.gameObject);
        }
        else if (collision.gameObject.tag == "ForwardTile")
        {
            StartCoroutine(ForwardPool());
           // TileSpawnManager.Instance.BackToForwardPool(collision.gameObject);
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        tileSpawnManager.SpawnTile();
        //if (other.gameObject.tag == "Player")
        //{
        //    TileSpawnManager.Instance.SpawnTile();
        //}
        if (other.gameObject.tag == "Coin" )
        {
            score.ScoreCalculator(10);
            other.gameObject.SetActive(false);
        }

        else if (other.gameObject.tag == "RightTile")
        {
            tempGameObject = other.gameObject;
            tempGameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
            StartCoroutine(RightPool());


        }

        else if (other.gameObject.tag =="ForwardTile")
        {
            tempGameObject = other.gameObject;
            tempGameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
            StartCoroutine(ForwardPool());
        }
    }

    IEnumerator ForwardPool()
    {
        yield return new WaitForSeconds(2f);
        TileSpawnManager.Instance.BackToForwardPool(tempGameObject);
        //TileSpawnManager.Instance.BackToRightPool(tempGameObject);
    }
    IEnumerator RightPool()
    {
        yield return new WaitForSeconds(2f);
        //TileSpawnManager.Instance.BackToForwardPool(tempGameObject);
        TileSpawnManager.Instance.BackToRightPool(tempGameObject);
    }
}
