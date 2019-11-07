using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 offset2;
    public bool useOffset2;
  
    void Start()
    {
        offset = transform.position - player.transform.position;
        offset2 = transform.forward * 2f;
        
    }


    void Update()
    {
        // Simple camera follow player
        //transform.position = new Vector3(player.transform.position.x,
        //    player.transform.position.y,
        //    transform.position.z
        //    ); 

        //if(useOffset2)
        //{
        //    transform.position = player.transform.position + offset + offset2;
        //}

        //else
        //{
        //    transform.position = player.transform.position + offset;

        //}

        //// Shake Camera 
        //useOffset2 = !useOffset2;

        //    transform.position = player.transform.position + offset;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
