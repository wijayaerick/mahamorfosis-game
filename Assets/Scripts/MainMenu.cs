using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    private const int NEWGAME = 0;
    private const int CONTINUE = 1;
    private const int SETTINGS = 2;
    private const int CREDIT = 3;
    private const int QUIT = 4;
    private const int BACK = 5;
    private const int LEVEL1 = 6;
    private const int LEVEL2 = 7;
    private const int LEVEL3 = 8;
    private const int LEVEL4 = 9;
    private const int LEVEL5 = 10;

    public Canvas canvas;
    public Button[] buttons;

	// Use this for initialization
	void Start () {
        // Get Components
        canvas = GetComponentInChildren<Canvas>();
        buttons = GetComponentsInChildren<Button>();

        // Add Listeners
        buttons[NEWGAME].onClick.AddListener(NewGameOnClick);
        buttons[CONTINUE].onClick.AddListener(ContinueOnClick);
        buttons[SETTINGS].onClick.AddListener(SettingsOnClick);
        buttons[CREDIT].onClick.AddListener(CreditOnClick);
        buttons[QUIT].onClick.AddListener(quitOnClick);
        buttons[BACK].onClick.AddListener(BackOnClick);
        buttons[LEVEL1].onClick.AddListener(Level1OnClick);

        // SetActive views
        buttons[BACK].gameObject.SetActive(false);
        buttons[LEVEL1].gameObject.SetActive(false);
        buttons[LEVEL2].gameObject.SetActive(false);
        buttons[LEVEL3].gameObject.SetActive(false);
        buttons[LEVEL4].gameObject.SetActive(false);
        buttons[LEVEL5].gameObject.SetActive(false);

        // enable button
        buttons[CONTINUE].enabled = false;
        buttons[SETTINGS].enabled = false;
        buttons[CREDIT].enabled = false;
        buttons[LEVEL2].enabled = false;
        buttons[LEVEL3].enabled = false;
        buttons[LEVEL4].enabled = false;
        buttons[LEVEL5].enabled = false;
    }

    private void Level1OnClick()
    {
        Application.LoadLevel(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void NewGameOnClick()
    {
        HideMainButtons();
        buttons[BACK].gameObject.SetActive(true);
        buttons[LEVEL1].gameObject.SetActive(true);
        buttons[LEVEL2].gameObject.SetActive(true);
        buttons[LEVEL3].gameObject.SetActive(true);
        buttons[LEVEL4].gameObject.SetActive(true);
        buttons[LEVEL5].gameObject.SetActive(true);
    }

    private void ContinueOnClick()
    {
        HideMainButtons();
        buttons[BACK].gameObject.SetActive(true);
        // load data (from playerprefs or database), then go to Levelx
    }

    private void SettingsOnClick()
    {
        HideMainButtons();
        buttons[BACK].gameObject.SetActive(true);
    }

    private void CreditOnClick()
    {
        HideMainButtons();
        buttons[BACK].gameObject.SetActive(true);
    }

    private void quitOnClick()
    {
        Application.Quit();
    }

    private void BackOnClick()
    {
        buttons[NEWGAME].gameObject.SetActive(true);
        buttons[CONTINUE].gameObject.SetActive(true);
        buttons[SETTINGS].gameObject.SetActive(true);
        buttons[CREDIT].gameObject.SetActive(true);
        buttons[QUIT].gameObject.SetActive(true);
        buttons[BACK].gameObject.SetActive(false);

        buttons[LEVEL1].gameObject.SetActive(false);
        buttons[LEVEL2].gameObject.SetActive(false);
        buttons[LEVEL3].gameObject.SetActive(false);
        buttons[LEVEL4].gameObject.SetActive(false);
        buttons[LEVEL5].gameObject.SetActive(false);
    }

    private void HideMainButtons()
    {
        buttons[NEWGAME].gameObject.SetActive(false);
        buttons[CONTINUE].gameObject.SetActive(false);
        buttons[SETTINGS].gameObject.SetActive(false);
        buttons[CREDIT].gameObject.SetActive(false);
        buttons[QUIT].gameObject.SetActive(false);
        buttons[BACK].gameObject.SetActive(true);
    }


}
