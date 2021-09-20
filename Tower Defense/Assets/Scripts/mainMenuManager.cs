using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenuManager : MonoBehaviour
{
    string scoreKeyword = "highscore";
    void Start()
    {
        this.transform.Find("Highscore").GetComponent<Text>().text="Highscore: "+PlayerPrefs.GetInt(scoreKeyword,0);
    }

    public void startGame(){
        SceneManager.LoadScene("MainGame");
    }

    public void showHighScores(){
        Debug.Log("Hacia las scores");
        //SceneManager.LoadScene("ScoresScene");
    }

    public void exitGame(){
        Application.Quit();
    }
}
