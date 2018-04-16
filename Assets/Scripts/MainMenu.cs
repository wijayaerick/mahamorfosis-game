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
    private const int RIGHT = 5;
    private const int LEFT = 6;
    private const int INITIALBUTTON = 7;
    private const int LEVEL3 = 8;
    private const int LEVEL4 = 9;
    private const int STARTGAME = 10;

    private int buttonState = NEWGAME;

    private AudioSource buttonClick;


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
        buttonClick = GetComponents<AudioSource>()[0];

        // Add Listeners
        buttons[NEWGAME].onClick.AddListener(NewGameOnClick);
        buttons[CONTINUE].onClick.AddListener(ContinueOnClick);
        buttons[SHOP].onClick.AddListener(ShopOnClick);
        buttons[LEADERBOARD].onClick.AddListener(LeaderboardOnClick);
        buttons[QUIT].onClick.AddListener(QuitOnClick);
        buttons[RIGHT].onClick.AddListener(RightOnClick);
        buttons[LEFT].onClick.AddListener(LeftOnClick);
        buttons[INITIALBUTTON].onClick.AddListener(InitialButton);
        buttons[LEVEL3].onClick.AddListener(Level3OnClick);
        buttons[LEVEL4].onClick.AddListener(Level4OnClick);
        buttons[STARTGAME].onClick.AddListener(StartGameOnClick);

        // SetActive views
        // buttons[RIGHT].gameObject.SetActive(false);
        // buttons[LEFT].gameObject.SetActive(false);
        buttons[INITIALBUTTON].gameObject.SetActive(false);
        buttons[LEVEL3].gameObject.SetActive(false);
        buttons[LEVEL4].gameObject.SetActive(false);
        username.gameObject.SetActive(false);
        difficulty.gameObject.SetActive(false);
        buttons[STARTGAME].gameObject.SetActive(false);

        HideMainButtons();

        //Set current button
        buttonState = NEWGAME;
        buttons[RIGHT].gameObject.SetActive(true);
        buttons[LEFT].gameObject.SetActive(true);
        buttons[buttonState].gameObject.SetActive(true);
    }

    private void LeftOnClick()
    {
        if(buttonState<=0){
            //overflow ke 5
            buttons[buttonState].gameObject.SetActive(false);
            buttonState = QUIT;
            buttons[buttonState].gameObject.SetActive(true);
        } else {
            buttons[buttonState].gameObject.SetActive(false);
            buttonState -= 1;
            buttons[buttonState].gameObject.SetActive(true);
        }
        // buttonClick.Play();
        // SceneManager.LoadScene(1);
    }

    private void InitialButton()
    {
        buttonClick.Play();
        SceneManager.LoadScene(2);
    }

    private void Level3OnClick()
    {
        buttonClick.Play();
        SceneManager.LoadScene(3);
    }

    private void Level4OnClick()
    {
        buttonClick.Play();
        SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void NewGameOnClick()
    {
        buttonClick.Play();
        HideMainButtons();
        //Sementara langsung ke story dulu
        StartGameOnClick();
        // buttons[RIGHT].gameObject.SetActive(true);
        // username.gameObject.SetActive(true);
        // difficulty.gameObject.SetActive(true);
        // buttons[STARTGAME].gameObject.SetActive(true);
    }

    private void ContinueOnClick()
    {
        buttonClick.Play();
        HideMainButtons();
        //Sementara langsung mulai dulu
        goToLevel1();
        // buttons[RIGHT].gameObject.SetActive(true);
        // buttons[LEFT].gameObject.SetActive(true);
        // buttons[LEVEL2].gameObject.SetActive(true);
        // buttons[LEVEL3].gameObject.SetActive(true);
        // buttons[LEVEL4].gameObject.SetActive(true);
    }

    private void ShopOnClick()
    {
        buttonClick.Play();
        HideMainButtons();
        //buttons[RIGHT].gameObject.SetActive(true);
    }

    private void LeaderboardOnClick()
    {
        buttonClick.Play();
        HideMainButtons();
        //buttons[RIGHT].gameObject.SetActive(true);
    }

    private void QuitOnClick()
    {
        buttonClick.Play();
        Application.Quit();
    }

    private void RightOnClick() 
    {
        if(buttonState>=4){
            //overflow ke 0
            buttons[buttonState].gameObject.SetActive(false);
            buttonState = NEWGAME;
            buttons[buttonState].gameObject.SetActive(true);
        } else {
            buttons[buttonState].gameObject.SetActive(false);
            buttonState += 1;
            buttons[buttonState].gameObject.SetActive(true);
        }

        // buttonClick.Play();
        // buttons[NEWGAME].gameObject.SetActive(true);
        // buttons[CONTINUE].gameObject.SetActive(true);
        // buttons[SHOP].gameObject.SetActive(true);
        // buttons[LEADERBOARD].gameObject.SetActive(true);
        // buttons[QUIT].gameObject.SetActive(true);
        // buttons[RIGHT].gameObject.SetActive(false);

        // buttons[LEFT].gameObject.SetActive(false);
        // buttons[LEVEL2].gameObject.SetActive(false);
        // buttons[LEVEL3].gameObject.SetActive(false);
        // buttons[LEVEL4].gameObject.SetActive(false);

        // username.gameObject.SetActive(false);
        // difficulty.gameObject.SetActive(false);
        // buttons[STARTGAME].gameObject.SetActive(false);
    }

    private void HideMainButtons()
    {
        buttons[NEWGAME].gameObject.SetActive(false);
        buttons[CONTINUE].gameObject.SetActive(false);
        buttons[SHOP].gameObject.SetActive(false);
        buttons[LEADERBOARD].gameObject.SetActive(false);
        buttons[QUIT].gameObject.SetActive(false);
        buttons[RIGHT].gameObject.SetActive(false);
        buttons[LEFT].gameObject.SetActive(false);
    }

    private void StartGameOnClick()
    {
        buttonClick.Play();
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
        SceneManager.LoadScene(2); // perlu diperhatikan
    }

    private void goToLevel1(){
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
        SceneManager.LoadScene(2); // perlu diperhatikan
    }


}
