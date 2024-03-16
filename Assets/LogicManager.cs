using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    private bool gameOver = false;

    private float timer = 15;
    public bool corBranca = true;
    public GameObject bolaPreta;
    public GameObject bolaBranca;

    public GameObject gameOverScreen;
    void Start(){
        bolaBranca.tag = "Death";
        bolaPreta.tag = "Score";
    }

    void Update(){
        if(!gameOver) {
            TrocaCor();
            TrocaTag();
        }
    }
    public void IncreaseScore(){
        score++;
        scoreText.text = score.ToString();
    }

    public bool GetGameOver(){
        return gameOver;
        
    }

    public void SetGameOver(bool g){
        gameOver = g;
        gameOverActivate();
    }

    public void TrocaCor(){
        if(timer > 0){
            timer -= Time.deltaTime;
            timerText.text = ((int) timer).ToString();
        } else{
            timer = 15;
            corBranca = !corBranca;
        }
    }

    public void TrocaTag(){
        if(corBranca){
            bolaBranca.tag = "Death";
            bolaPreta.tag = "Score";
        } else{
            bolaBranca.tag = "Score";
            bolaPreta.tag = "Death";
        }
    }
    
    public void gameOverActivate(){
        gameOverScreen.SetActive(true);
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void menu(){
        SceneManager.LoadScene("MenuScene");
    }
}
