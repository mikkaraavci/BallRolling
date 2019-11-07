using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : MonoBehaviour
{
    private Vector3 initialPosition;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(ClearTextAfter5Seconds());
            DataManager.dataManager.ReLoadLevel();

            //int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            //SceneManager.LoadScene(sceneIndex + 1);
            //SceneManager.LoadScene(0); (restart scene)
            //player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //player.transform.position = initialPosition;
            //player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        }
    }

    private IEnumerator ClearTextAfter5Seconds()
    {
        yield return new WaitForSeconds(100f);
        
    }
}
