using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
public class gameManager : MonoBehaviour
{

    public static gameManager instance;

    public GameObject hud;
    public GameObject messagePanel;
    public Slider progressSlider;
    public GameObject nexus;
    public GameObject board;
    
    static bool onPause;

    static bool fastSpeed;
    int totalEnemies;
    int spawnedEnemies;
    int killedEnemies;
    float levelProgress;
    public int CurrentEnemies {
        get{
           return 0; 
        } 
        set{
            if(value>0){
                spawnedEnemies++;
            }else if(value<0){ killedEnemies++; scoreManager.instance.addToScore(10);}

            levelProgress= progressSlider.value = (float)(spawnedEnemies+killedEnemies)/(2*totalEnemies);
            
            if(levelProgress>=1){
                endGame(true);
            }
        } 
    
    }     

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }
    void Start()
    {
        onPause = false; 
        fastSpeed=false;
        board = GameObject.Find("Board");
        nexus= GameObject.Find("Nexus");
        messagePanel = GameObject.Find("Message panel");
        messagePanel.SetActive(false);
        hud = GameObject.Find("HUD");
        progressSlider = hud.transform.Find("Progress Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void addTotalEnemies(int value){
        totalEnemies+=value;
    }

    public void tooglePause(){
        //Debug.Log("Pausa? "+onPause);
        onPause= !onPause;
        if(onPause){
            //sacar mensaje de pausa?
            Time.timeScale*=0.01f;
        }else{
            Time.timeScale/=0.01f;
        }
    }

    public void toogleGameSpeed(){
        fastSpeed=!fastSpeed;
        if(fastSpeed){
            Time.timeScale*=2;
        }else{
            Time.timeScale/=2;
        }
    }
    public Vector3 getNexusPosition(){
        return nexus.transform.position;
    }

    public void endGame(bool gameWon){
        string message="";
        hud.SetActive(false);
        board.BroadcastMessage("stop",SendMessageOptions.DontRequireReceiver);
        if(gameWon){
            message = "Level passed";
        }else{
            message = "Try again";
        }
        messagePanel.SetActive(true);
        messagePanel.transform.Find("Message").GetComponent<Text>().text= message;
        messagePanel.transform.Find("Score").GetComponent<Text>().text = scoreManager.instance.checkOutScore(gameWon).ToString();
    }

    public void toMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
