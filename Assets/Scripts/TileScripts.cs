using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScripts : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        TileSpawnManager.Instance.SpawnTile();
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FallDown());
        }
       
    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(0.2f);
        print("Falling Down");
        rb.isKinematic = false;
        yield return new WaitForSeconds(2f);
        print("Stop Falling");
        rb.isKinematic = true;
        if (TileSpawnManager.Instance.name == "RightTile")
        {
            TileSpawnManager.Instance.BackToRightPool(gameObject);
        }
        else if (TileSpawnManager.Instance.name == "ForwardTile")
        {
            TileSpawnManager.Instance.BackToForwardPool(gameObject);
        }
      
        
    }
}
