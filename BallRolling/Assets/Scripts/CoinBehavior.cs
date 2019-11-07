using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour
{
    private float amount = 5f;
    private void OnTriggerEnter(Collider other)
    {   
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().setScore(amount);
            
            Destroy(gameObject);

        }
        


    }

}
