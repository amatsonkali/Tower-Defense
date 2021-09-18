using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform meta;
    public int health;
    void Start()
    {
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination( gameManager.instance.getNexusPosition() );
        //gameManager.instance.currentEnemies++;
        gameManager.instance.CurrentEnemies++;
    }

    void takeDamage(int dmg){
        health-=dmg;
        if(health <=0){
            //gameManager.instance.currentEnemies--;
            gameManager.instance.CurrentEnemies--;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag.Contains("Nexus")){
            gameManager.instance.endGame(false);
        }
    }
}
