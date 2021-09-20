using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag.Contains("Enemy") ){
            other.gameObject.SendMessage("takeDamage",damage);
        }
        Destroy(this.gameObject,0.5f);
    }
}
