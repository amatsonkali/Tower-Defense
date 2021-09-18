using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

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
        nexus= GameObject.Find("Nexus");
    }

    // Update is called once per frame
    void Update()
    {
        
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
