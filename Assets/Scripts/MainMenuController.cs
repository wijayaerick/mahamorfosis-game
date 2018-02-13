using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    private const int NEWGAME = 0;
    private const int CONTINUE = 1;
    private const int SETTINGS = 2;
    private const int CREDIT = 3;
    private const int QUIT = 4;
    private const int BACK = 5;

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

        // SetActive views
        buttons[BACK].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void NewGameOnClick()
    {
        HideMainButtons();
        buttons[BACK].gameObject.SetActive(true);
        // go to Level1.asset
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
