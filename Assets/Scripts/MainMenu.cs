using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private const int NEWGAME = 0;
    private const int CONTINUE = 1;
    private const int SHOP = 2;
    private const int LEADERBOARD = 3;
    private const int QUIT = 4;
    private const int BACK = 5;
    private const int LEVEL1 = 6;
    private const int LEVEL2 = 7;
    private const int LEVEL3 = 8;
    private const int LEVEL4 = 9;
    private const int STARTGAME = 10;


    public Canvas canvas;
    public Button[] buttons;
    public InputField username;
    public Dropdown difficulty;
    

	void Start () {
        // Get Components
        canvas = GetComponentInChildren<Canvas>();
        buttons = GetComponentsInChildren<Button>();
        username = GetComponentInChildren<InputField>();
        difficulty = GetComponentInChildren<Dropdown>();

        // Add Listeners
        buttons[NEWGAME].onClick.AddListener(NewGameOnClick);
        buttons[CONTINUE].onClick.AddListener(ContinueOnClick);
        buttons[SHOP].onClick.AddListener(ShopOnClick);
        buttons[LEADERBOARD].onClick.AddListener(LeaderboardOnClick);
        buttons[QUIT].onClick.AddListener(QuitOnClick);
        buttons[BACK].onClick.AddListener(BackOnClick);
        buttons[LEVEL1].onClick.AddListener(Level1OnClick);
        buttons[LEVEL2].onClick.AddListener(Level2OnClick);
        buttons[LEVEL3].onClick.AddListener(Level3OnClick);
        buttons[LEVEL4].onClick.AddListener(Level4OnClick);
        buttons[STARTGAME].onClick.AddListener(StartGameOnClick);

        // SetActive views
        buttons[BACK].gameObject.SetActive(false);
        buttons[LEVEL1].gameObject.SetActive(false);
        buttons[LEVEL2].gameObject.SetActive(false);
        buttons[LEVEL3].gameObject.SetActive(false);
        buttons[LEVEL4].gameObject.SetActive(false);
        username.gameObject.SetActive(false);
        difficulty.gameObject.SetActive(false);
        buttons[STARTGAME].gameObject.SetActive(false);

        // enable button
    }

    private void Level1OnClick()
    {
        SceneManager.LoadScene(1);
    }

    private void Level2OnClick()
    {
        SceneManager.LoadScene(2);
    }

    private void Level3OnClick()
    {
        SceneManager.LoadScene(3);
    }

    private void Level4OnClick()
    {
        SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void NewGameOnClick()
    {
        HideMainButtons();
        buttons[BACK].gameObject.SetActive(true);
        username.gameObject.SetActive(true);
        difficulty.gameObject.SetActive(true);
        buttons[STARTGAME].gameObject.SetActive(true);
    }

    private void ContinueOnClick()
    {
        HideMainButtons();
        buttons[BACK].gameObject.SetActive(true);
        buttons[LEVEL1].gameObject.SetActive(true);
        buttons[LEVEL2].gameObject.SetActive(true);
        buttons[LEVEL3].gameObject.SetActive(true);
        buttons[LEVEL4].gameObject.SetActive(true);
    }

    private void ShopOnClick()
    {
        HideMainButtons();
        buttons[BACK].gameObject.SetActive(true);
    }

    private void LeaderboardOnClick()
    {
        HideMainButtons();
        buttons[BACK].gameObject.SetActive(true);
    }

    private void QuitOnClick()
    {
        Application.Quit();
    }

    private void BackOnClick()
    {
        buttons[NEWGAME].gameObject.SetActive(true);
        buttons[CONTINUE].gameObject.SetActive(true);
        buttons[SHOP].gameObject.SetActive(true);
        buttons[LEADERBOARD].gameObject.SetActive(true);
        buttons[QUIT].gameObject.SetActive(true);
        buttons[BACK].gameObject.SetActive(false);

        buttons[LEVEL1].gameObject.SetActive(false);
        buttons[LEVEL2].gameObject.SetActive(false);
        buttons[LEVEL3].gameObject.SetActive(false);
        buttons[LEVEL4].gameObject.SetActive(false);

        username.gameObject.SetActive(false);
        difficulty.gameObject.SetActive(false);
        buttons[STARTGAME].gameObject.SetActive(false);
    }

    private void HideMainButtons()
    {
        buttons[NEWGAME].gameObject.SetActive(false);
        buttons[CONTINUE].gameObject.SetActive(false);
        buttons[SHOP].gameObject.SetActive(false);
        buttons[LEADERBOARD].gameObject.SetActive(false);
        buttons[QUIT].gameObject.SetActive(false);
        buttons[BACK].gameObject.SetActive(true);
    }

    private void StartGameOnClick()
    {
        Data.difficulty = difficulty.value;
        Data.level = 0;
        Data.score = 0;
        Data.money = 0;
        Data.furthestLevel = Data.level;
        Data.healthLevel = 0;
        Data.damageLevel = 0;
        Data.speedLevel = 0;
        Data.stars[0] = 0;
        Data.stars[1] = 0;
        Data.stars[2] = 0;
        Data.stars[3] = 0;
        Data.scores[0] = 0;
        Data.scores[1] = 0;
        Data.scores[2] = 0;
        Data.scores[3] = 0;
        SceneManager.LoadScene(1);
    }


}
