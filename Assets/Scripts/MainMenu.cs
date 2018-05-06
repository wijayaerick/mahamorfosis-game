using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private const int NEWGAME = 0;
    private const int CONTINUE = 1;
    private const int SHOP = 2;
    private const int LEADERBOARD = 3;
    private const int OPTION = 4;
    private const int QUIT = 5;
    private const int RIGHT = 6;
    private const int LEFT = 7;
    private const int INITIALBUTTON = 8;
    private const int BACK = 9;
    private const int CANCEL = 10;
    private const int OTAK = 11;
    private const int HATI = 12;
    private const int STARTGAME = 13;
    private int buttonState = NEWGAME;

    private AudioSource buttonClick;
    public AudioMixer mixer;
    public Slider music;
    public Slider sfx;

    public Canvas canvas;
    private Button[] buttons;
    public InputField username;
    public Dropdown difficulty;
    public GameObject leaderboard;
    public GameObject mainLogo;
    public GameObject shop;
    public GameObject option;
    public GameObject pickCharacter;
    public Sprite otakNotClick;
    public Sprite otakClick;
    public Sprite hatiNotClick;
    public Sprite hatiClick;
    
	void Start () {
        // Get Components
        canvas = GetComponentInChildren<Canvas>();
        buttons = GetComponentsInChildren<Button>();
        //username = GetComponentInChildren<InputField>();
        //difficulty = GetComponentInChildren<Dropdown>();
        buttonClick = GetComponent<AudioSource>();

        // Add Listeners
        buttons[NEWGAME].onClick.AddListener(NewGameOnClick);
        buttons[CONTINUE].onClick.AddListener(ContinueOnClick);
        buttons[SHOP].onClick.AddListener(ShopOnClick);
        buttons[LEADERBOARD].onClick.AddListener(LeaderboardOnClick);
        buttons[OPTION].onClick.AddListener(OptionOnClick);
        buttons[QUIT].onClick.AddListener(QuitOnClick);
        buttons[RIGHT].onClick.AddListener(RightOnClick);
        buttons[LEFT].onClick.AddListener(LeftOnClick);
        buttons[INITIALBUTTON].onClick.AddListener(InitialButton);
        buttons[BACK].onClick.AddListener(BackOnClick);
        buttons[CANCEL].onClick.AddListener(CancelOnClick);
        buttons[OTAK].onClick.AddListener(OtakOnClick);
        buttons[HATI].onClick.AddListener(HatiOnClick);
        buttons[STARTGAME].onClick.AddListener(StartGameOnClick);

        // SetActive views
        // buttons[RIGHT].gameObject.SetActive(false);
        // buttons[LEFT].gameObject.SetActive(false);
        buttons[BACK].gameObject.SetActive(false);
        buttons[CANCEL].gameObject.SetActive(false);
        buttons[OTAK].gameObject.SetActive(false);
        buttons[HATI].gameObject.SetActive(false);
        // buttons[OPTION].gameObject.SetActive(false);
        //username.gameObject.SetActive(false);
        //difficulty.gameObject.SetActive(false);
        leaderboard.SetActive(false);
        option.SetActive(false);
        shop.SetActive(false);
        pickCharacter.SetActive(false);
        buttons[STARTGAME].gameObject.SetActive(false);

        HideMainButtons();
        buttons[INITIALBUTTON].gameObject.SetActive(true);
        //Set current button
        
        // Audio
        music.onValueChanged.AddListener(delegate {SetPlayerPrefsMusic(); });
        sfx.onValueChanged.AddListener(delegate {SetPlayerPrefsSFX(); });
        music.value = PlayerPrefs.GetFloat("Music", 1);
        sfx.value = PlayerPrefs.GetFloat("SFX", 1);
        SetPlayerPrefsMusic();
        SetPlayerPrefsSFX();

    }
    
    private void SetPlayerPrefsMusic() {
        PlayerPrefs.SetFloat("Music", music.value);
        mixer.SetFloat("Volume Music",  Mathf.Log10(music.value) * 30);
    }
    private void SetPlayerPrefsSFX() {
        PlayerPrefs.SetFloat("SFX", sfx.value);
        mixer.SetFloat("Volume SFX",  Mathf.Log10(sfx.value) * 30);
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
        buttonClick.Play();
        // SceneManager.LoadScene(1);
    }

    private void RightOnClick() 
    {
        if(buttonState>=5){
            //overflow ke 0
            buttons[buttonState].gameObject.SetActive(false);
            buttonState = NEWGAME;
            buttons[buttonState].gameObject.SetActive(true);
        } else {
            buttons[buttonState].gameObject.SetActive(false);
            buttonState += 1;
            buttons[buttonState].gameObject.SetActive(true);
        }
        buttonClick.Play();
    }

    private void InitialButton()
    {
        // buttonClick.Play();
        // SceneManager.LoadScene(2);
        buttons[INITIALBUTTON].gameObject.SetActive(false);
        buttonState = NEWGAME;
        buttons[RIGHT].gameObject.SetActive(true);
        buttons[LEFT].gameObject.SetActive(true);
        buttons[buttonState].gameObject.SetActive(true);
    }

    private void BackOnClick()
    {
        buttonClick.Play();
        // SceneManager.LoadScene(3);
        if(leaderboard.activeSelf){
            leaderboard.SetActive(false);
            showCurrentMenu(LEADERBOARD);
        } else if(shop.activeSelf) {
            shop.SetActive(false);
            showCurrentMenu(SHOP);
        } else if(option.activeSelf) {
            option.SetActive(false);
            showCurrentMenu(OPTION);
        }
        buttons[BACK].gameObject.SetActive(false);
        mainLogo.SetActive(true);
        
    }

    private void OptionOnClick()
    {
        buttonClick.Play();
        HideMainButtons();
        option.SetActive(true);
        mainLogo.SetActive(false);
        buttons[BACK].gameObject.SetActive(true);
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
        mainLogo.SetActive(false);
        pickCharacter.SetActive(true);
        buttons[CANCEL].gameObject.SetActive(true);
        buttons[STARTGAME].gameObject.SetActive(true);
        buttons[OTAK].gameObject.SetActive(true);
        buttons[HATI].gameObject.SetActive(true);
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
        shop.SetActive(true);
        mainLogo.SetActive(false);
        buttons[BACK].gameObject.SetActive(true);
    }

    private void LeaderboardOnClick()
    {
        buttonClick.Play();
        HideMainButtons();
        leaderboard.SetActive(true);
        mainLogo.SetActive(false);
        buttons[BACK].gameObject.SetActive(true);

        //buttons[RIGHT].gameObject.SetActive(true);
    }

    private void QuitOnClick()
    {
        buttonClick.Play();
        Application.Quit();
    }

    private void CancelOnClick()
    {
        buttonClick.Play();
        pickCharacter.SetActive(false);
        showCurrentMenu(NEWGAME);
        buttons[CANCEL].gameObject.SetActive(false);
        buttons[STARTGAME].gameObject.SetActive(false);
        buttons[OTAK].gameObject.SetActive(false);
        buttons[HATI].gameObject.SetActive(false);
        mainLogo.SetActive(true);
    }

    private void OtakOnClick()
    {
        buttonClick.Play();
        if(buttons[OTAK].gameObject.GetComponent<Image>().sprite == otakNotClick){
            if(buttons[HATI].gameObject.GetComponent<Image>().sprite == hatiClick){
                buttons[HATI].gameObject.GetComponent<Image>().sprite = hatiNotClick;
            }
            buttons[OTAK].gameObject.GetComponent<Image>().sprite = otakClick;
        }
        
    }

    private void HatiOnClick()
    {
        buttonClick.Play();
        if(buttons[HATI].gameObject.GetComponent<Image>().sprite == hatiNotClick){
            if(buttons[OTAK].gameObject.GetComponent<Image>().sprite == otakClick){
                buttons[OTAK].gameObject.GetComponent<Image>().sprite = otakNotClick;
            }
            buttons[HATI].gameObject.GetComponent<Image>().sprite = hatiClick;
        }
    }

    private void HideMainButtons()
    {
        buttons[NEWGAME].gameObject.SetActive(false);
        buttons[CONTINUE].gameObject.SetActive(false);
        buttons[SHOP].gameObject.SetActive(false);
        buttons[LEADERBOARD].gameObject.SetActive(false);
        buttons[OPTION].gameObject.SetActive(false);
        buttons[QUIT].gameObject.SetActive(false);
        buttons[RIGHT].gameObject.SetActive(false);
        buttons[LEFT].gameObject.SetActive(false);
    }

    private void ShowMainButtons()
    {
        buttons[NEWGAME].gameObject.SetActive(true);
        buttons[CONTINUE].gameObject.SetActive(true);
        buttons[SHOP].gameObject.SetActive(true);
        buttons[LEADERBOARD].gameObject.SetActive(true);
        buttons[OPTION].gameObject.SetActive(true);
        buttons[QUIT].gameObject.SetActive(true);
        buttons[RIGHT].gameObject.SetActive(true);
        buttons[LEFT].gameObject.SetActive(true);
    }

    private void showCurrentMenu(int id)
    {
        buttons[id].gameObject.SetActive(true);
        buttons[RIGHT].gameObject.SetActive(true);
        buttons[LEFT].gameObject.SetActive(true);
    }

    private void StartGameOnClick()
    {
        buttonClick.Play();
        //Data.difficulty = difficulty.value;
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
        //Data.difficulty = difficulty.value;
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
        SceneManager.LoadScene(1); // perlu diperhatikan
    }


}
