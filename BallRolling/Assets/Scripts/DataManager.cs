using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class DataManager : MonoBehaviour
{
    public static DataManager dataManager;
    public float score = 0f;
    public float initialScore;

    private void Awake()
    {
        if(DataManager.dataManager == null)
        {

            DataManager.dataManager = this;
        }
        else
        {   
            if(this != DataManager.dataManager)
            {
                Destroy(this.gameObject);
            }

            
        }
        DontDestroyOnLoad(DataManager.dataManager.gameObject);
    }


    public void ReLoadLevel()
    {
        score = initialScore;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
        UIController.uiController.SetScoreText(initialScore.ToString());

    }

    public void LoadNextLevel()
    {
        initialScore = score;
        
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
       

        
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/gameSave.gmsv",
            FileMode.Create);

        bf.Serialize(stream, initialScore); //
        bf.Serialize(stream, SceneManager.GetActiveScene().buildIndex); //

        stream.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameSave.gmsv"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/gameSave.gmsv",
               FileMode.Open);

            initialScore = (float) bf.Deserialize(stream);
            int savedSceneIndex = (int)bf.Deserialize(stream);

            stream.Close();

            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(savedSceneIndex);


          
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIController.uiController.SetScoreText(initialScore.ToString());
        score = initialScore;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
