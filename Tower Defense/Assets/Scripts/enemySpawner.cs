using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class enemySpawner : MonoBehaviour
{
    private int totalEnemies;
    [SerializeField]
    private List<EnemyClassif> enemyPool;

    [SerializeField]
    public List<EnemySet> enemyRounds;
    void Start()
    {
        StartCoroutine("Horde");
        foreach (EnemySet round in enemyRounds)
        {
            totalEnemies+= round.enemyTypes.Count;
        }
        gameManager.instance.addTotalEnemies(totalEnemies);
    }

    IEnumerator Horde() {
        EnemySet currentRound;
        for(;;){
            while(enemyRounds.Count > 0){
                currentRound = enemyRounds[0];
                yield return new WaitForSeconds(currentRound.delay);
                foreach (enemyType etype in currentRound.enemyTypes)
                {
                    GameObject newEnemy = Instantiate(enemyPool.Find( x=> x.type==etype ).enemyPrefab,this.transform,false );
                    yield return new WaitForSeconds(1);
                }

                enemyRounds.RemoveAt(0);
            }
            yield return null;
        }
    }
}
