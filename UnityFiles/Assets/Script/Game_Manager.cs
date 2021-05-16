using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    GameObject Panel;
    Text Message;
    GameObject Player;
    Vector3 start_pos; // playerの初期位置

    public int score = 0;
    Text ScoreText;

    Slider HPSlider;
    int maxHP = 100;

    bool gameover = false;
    bool clear = false;

    GameObject MovingBlock;

    



    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("Panel");

        Message = GameObject.Find("Message").GetComponent<Text>();
        Message.text = "";

        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        start_pos = Player.transform.position;

        score = 0;
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        getScore(0);

        HPSlider = GameObject.Find("HPSlider").GetComponent<Slider>();
        HPSlider.maxValue = maxHP;
        HPSlider.value = maxHP;

        MovingBlock = GameObject.Find("Moving_Block1");
        MovingBlock.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
        fall();

    }

    
    void init()
    {
        Player.transform.position = start_pos;
    }

    void restart()
    {
        Message.text = "RESTART";
        Invoke("deleteMessage",1.5f);
        init();
    }

    void deleteMessage()
    {
        Message.text = "";
    }

    void gameOver(){
        gameover = true;
        Message.text = "GAME OVER";
        // Panel.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.38f);
        Invoke("moveMenuScene", 3.0f);
    }

    void clearMessage(){
        Message.text = "CONGRATULATIONS!!";
        // Panel.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.38f);
    }

    public void clearGame(){
        clear = true;
        getScore((int)HPSlider.value * 10);
        clearMessage();

        if(PlayerPrefs.HasKey("HighScore")){
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            if(score > highScore){
                PlayerPrefs.SetInt("HighScore", score);
            }
        }else{
            PlayerPrefs.SetInt("HighScore", score);
        }

        Invoke("moveMenuScene", 5.0f);
    }

    void moveMenuScene(){
        FadeManager.Instance.LoadScene("Menu", 3.0f);
    }

    void fall(){
        // Debug.Log(Player.name);
        if(Player.transform.position.y < -50){
            restart();
            downHP(10);
        }
    }

    public void getScore(int get_score){
        score += get_score;
        ScoreText.text = "Score : " + score;

    }

    public void downHP(int down){
        HPSlider.value -= down;
        if(HPSlider.value <= 0){
            gameOver();
        }
    }

    public void panelRed(){
        Panel.GetComponent<Image>().color = new Color(1f, 0f, 0f, 0.38f); 
        Invoke("reset_panel", 1f);
    }

    void reset_panel(){
        Panel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f); 
    }


    public void putMoveBlock(){
        MovingBlock.SetActive(true);
    }

    
}
