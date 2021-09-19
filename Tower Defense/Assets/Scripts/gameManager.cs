using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class gameManager : MonoBehaviour
{

    public static gameManager instance;
    public Slider progressSlider;
    static bool onPause;

    static bool fastSpeed;
    public GameObject nexus;
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
            }else if(value<0) killedEnemies++;

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
        nexus= GameObject.Find("Nexus");
        progressSlider = GameObject.Find("Progress Slider").GetComponent<Slider>();
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
        if(gameWon){
            Debug.Log("Ganas");
        }else{
            Debug.Log("Game over");
        }
    }
}
