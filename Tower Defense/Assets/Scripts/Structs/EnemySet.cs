using System.Collections.Generic;
using System;
using UnityEngine;

public enum enemyType {normal,strong};
 [Serializable]
public struct EnemySet
{
    public int delay;
    public List<enemyType> enemyTypes;
}
[Serializable]
public struct EnemyClassif
{
    public enemyType type;
    public GameObject enemyPrefab;

}