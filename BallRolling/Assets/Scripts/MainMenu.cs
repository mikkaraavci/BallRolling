using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton, loadButton, settinsButton, creditsButton, quitButton;
    public Button settingsPanelCloseButton;
    public Transform settingsPanel;
    void Start()
    {

        newGameButton.onClick.AddListener(StartNewGame);
        loadButton.onClick.AddListener(LoadSaveGame);
        settinsButton.onClick.AddListener(OpenSettingsPanel);
        quitButton.onClick.AddListener(QuitGame);


        settingsPanelCloseButton.onClick.AddListener(CloseSettingsPanelButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartNewGame()
    {
        DataManager.dataManager.score = 0;
        DataManager.dataManager.initialScore = 0;
        if(UIController.uiController != null)
        {
            UIController.uiController.SetScoreText("0");
        }
        SceneManager.LoadScene(1);
    }

    private void LoadSaveGame()
    {
        DataManager.dataManager.Load();
       
    }

    private void OpenSettingsPanel()
    {
        // transform.Find("SettingsPnael").gameObject.SetActive(true); // referanssız settings panel açma
        settingsPanel.gameObject.SetActive(true);
    }

    private void CloseSettingsPanelButton()
    {
        settingsPanel.gameObject.SetActive(false);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
