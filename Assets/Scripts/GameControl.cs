using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public TextMeshProUGUI txtPoint;
    public TextMeshProUGUI txtPlayAgain;
    public TextMeshProUGUI txtHighScore;
    private int score = 0;
    private int highscore = 0;
    bool isEndGame;
    
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        Time.timeScale = 0;
        txtPlayAgain.text = "Hit space to jump";
        txtHighScore.text = "Highscore: " + highscore.ToString();
        isEndGame = false;
        

    }

    private void Update()
    {
        ControlGame();
    }
    
    private void ControlGame()
    {
        switch(isEndGame)
        {
            case true:
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        //Reload the scene
                        SceneManager.LoadScene(0);
                    }
                    break;
                }
            case false:
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Time.timeScale = 1;
                        txtPlayAgain.text = "";
                    }
                    break;
                }
            default:
                break;
        }        
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        txtPlayAgain.text = "Hit Space to \nplay again";
        isEndGame = true;
    }
    public void GetPoint()
    {
        score += 1;
        txtPoint.text = score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }

    }




}
