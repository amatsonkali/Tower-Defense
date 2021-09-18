using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<EnemyClassif> enemyPool;

    [SerializeField]
    public List<EnemySet> enemyRounds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Horde");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Horde() {
        EnemySet currentRound;
        for(;;){
            while(enemyRounds.Count > 0){
                currentRound = enemyRounds[0];
                //delay
                //Debug.Log("Aplicando delay de "+currentRound.delay);
                yield return new WaitForSeconds(currentRound.delay);
                //spawn
                foreach (enemyType etype in currentRound.enemyTypes)
                {
                    GameObject newEnemy = Instantiate(enemyPool.Find( x=> x.type==etype ).enemyPrefab,this.transform.position,Quaternion.identity );
                    //Debug.Log("Enemigo instanciado: "+etype);
                    yield return new WaitForSeconds(1);
                }

                enemyRounds.RemoveAt(0);
            }
            yield return null;
        }
    }
}
