using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;

    static bool onPause;

    static bool fastSpeed;


    public GameObject nexus;
    public int currentEnemies;
    public int CurrentEnemies {
        get{
           return currentEnemies; 
        } 
        set{
            Debug.Log("Enemigos: "+value); 
            currentEnemies=value;
            //TODO: Comprobar que no hay mas olas de enemigos
            if(currentEnemies<1) endGame(true); 
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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void tooglePause(){
        //Debug.Log("Pausa? "+onPause);
        onPause= !onPause;
        if(onPause){
            //sacar mensaje de pausa
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
