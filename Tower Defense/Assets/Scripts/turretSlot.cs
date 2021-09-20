using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool usedSlot;
    void Start()
    {
        //Instanciar botones conforme a la pool?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnTurret(GameObject turret){
        if(!usedSlot){
        Instantiate(turret,this.transform);
        usedSlot=true;
        }else{
            Debug.Log("Slot ocupado");
        }
    }
}
