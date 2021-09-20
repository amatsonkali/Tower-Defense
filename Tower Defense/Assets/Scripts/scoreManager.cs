using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    public int score;
    public int drainPerSecond;

    string scoreKeyword = "highscore";
    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine("drainScore");
    }

    public void addToScore(int value){
        score+=value;
    }

    public int checkOutScore(){
        StopCoroutine("drainScore");
        if(score > PlayerPrefs.GetInt(scoreKeyword,-1)){
            Debug.Log("Score guardada: "+scoreKeyword);
            PlayerPrefs.SetInt(scoreKeyword,score);
        }
        return score;
    }
    IEnumerator drainScore() 
    {
        for(;;) 
        {
            if( (score-drainPerSecond)>=0 ){
                score-=drainPerSecond;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
