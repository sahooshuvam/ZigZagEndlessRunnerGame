using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 direction;
    public float playerSpeed;
    TileSpawnManager spawnTile;
    ScoreManager score;
    public GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        spawnTile = GameObject.Find("TileSpawnManager").GetComponent<TileSpawnManager>();
        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();


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



    //public void OnCollisionEnter(Collision other)
    //{

    //     TileSpawnManager.Instance.SpawnTile();

    //    if (other.gameObject.tag == "Coin")
    //    {
    //        score.ScoreUpdate(10);
    //    }

    //}

    //public void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Right")
    //    {
    //        TileSpawnManager.Instance.BackToRightPool(collision.gameObject);
    //        temp = collision.gameObject;           
    //    }
    //    if (collision.gameObject.tag == "Forward")
    //    {
    //        TileSpawnManager.Instance.BackToForwardPool(collision.gameObject);
    //        temp = collision.gameObject;
    //    }

    //}
    //IEnumerator RightPool()
    //{
    //    yield return new WaitForSeconds(1f);
    //    TileSpawnManager.Instance.BackToRightPool(temp);
    //}
    //IEnumerator ForwardPool()
    //{
    //    yield return new WaitForSeconds(1f);
    //    TileSpawnManager.Instance.BackToForwardPool(temp);
    //}








}
