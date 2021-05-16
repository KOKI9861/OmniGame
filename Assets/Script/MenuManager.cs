using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : ActionObject
{
    bool startflag;
    bool exitflag;
    Text MenuText;
    Text HighScoreText;
    bool moveflag;

    // Start is called before the first frame update
    void Start()
    {

        MenuText = GameObject.Find("MenuText").GetComponent<Text>();
        switchMenu(true);

        HighScoreText = GameObject.Find("HighScore").GetComponent<Text>();
        int highScore = 0;
        if(PlayerPrefs.HasKey("HighScore")){
            highScore = PlayerPrefs.GetInt("HighScore", 0);
        }
        HighScoreText.text = "High Score : " + highScore;

        moveflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        selectMenu();
    }

    void switchMenu(bool switch_start){
        if(switch_start){
            startflag = true;
            exitflag = false;
            MenuText.text = ">START\n  EXIT";
        }else{
            startflag = false;
            exitflag = true;
            MenuText.text = "  START\n>EXIT";
        }
    }

    void selectMenu(){
        if(Input.GetKeyDown("up")){
            switchMenu(true);
        }
        if(Input.GetKeyDown("down")){
            switchMenu(false);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            moveScene();
        }
    }

    void moveScene(){
        if(startflag){
            // SceneManager.LoadScene("Koki's planet");
            moveflag = true;
            FadeManager.Instance.LoadScene("Koki's planet", 1.0f);
        }
    }

    protected override void TriggerTouchDown(float x, params object[] args){
        if(!moveflag){
            moveScene();
        }
    }

    protected override void StickPadClicked(float x, float y, params object[] args){
        if(y>0){
            switchMenu(true);
        }else{
            switchMenu(false);
        }
    }

    
}
