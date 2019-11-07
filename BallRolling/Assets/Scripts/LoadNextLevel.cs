using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
   
   



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

               
                DataManager.dataManager.LoadNextLevel();
            

        }
    }

    
}
