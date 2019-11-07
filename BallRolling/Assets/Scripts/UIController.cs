using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController uiController;
    public GameObject player;
    public Text scoreText;
    public Button saveButton, loadButton, resumeButton, mainMenuButton, menuButton;
    public Transform inGameMenuPanel;
    //public GameObject player;
    // Start is called before the first frame update

    private void Awake()
    {
        //  if uiController is null 
        // uiController is me
        if (uiController == null)
        {
            UIController.uiController = this;
        }

        // if is not
        // if i am not uiController 
        else
        {
            if(this !=UIController.uiController)
            {
                // destroy me bcs i dont touch uiController
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(UIController.uiController.gameObject);
        
        // current uiController dont destroy when load 
    }
    void Start()
    {
        scoreText.text = "Score :" + DataManager.dataManager.score.ToString();
        saveButton.onClick.AddListener(SaveGame);
        loadButton.onClick.AddListener(LoadGame);
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(QuitMainMenuGame);
        menuButton.onClick.AddListener(OpenInGameMenu);
    }

    // Update is called once per frame
   

    public void SetScoreText(string aScoreString)
    {
        scoreText.text ="Score :" + aScoreString;

    }

    private void SaveGame()
    {
        DataManager.dataManager.Save();
    }

    private void LoadGame()
    {
        DataManager.dataManager.Load();
    }

    private void ResumeGame()
    {
        inGameMenuPanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void QuitMainMenuGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
        inGameMenuPanel.gameObject.SetActive(false);

    }

    private void OpenInGameMenu()
    {
        Time.timeScale = 0;
        inGameMenuPanel.gameObject.SetActive(true);
    }
}
