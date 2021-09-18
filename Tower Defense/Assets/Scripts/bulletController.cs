using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag.Contains("Enemy") ){
            other.gameObject.SendMessage("takeDamage",damage);
        }
        Destroy(this.gameObject,0.5f);
    }
}
