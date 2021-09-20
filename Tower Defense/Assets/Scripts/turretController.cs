using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    public float range;
    public int damage;
    public float attackSpeed;
    public int shootForce;
    public GameObject bullet;
    public List<GameObject> targets = new List<GameObject>();
    Transform head;
    void Start()
    {
        head = this.transform.Find("Head");
        this.gameObject.GetComponent<SphereCollider>().radius = range;
        StartCoroutine("Patrol");
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag.Contains("Enemy") ){
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag.Contains("Enemy")){
            targets.Remove(other.gameObject);
        }
    }
    void Update()
    {
        if(targets.Count>0 ){
            if(targets[0]!=null){
                head.LookAt(targets[0].transform);
            }else {
                targets.RemoveAt(0);
            }
        }
    }

    void Shoot(){
        GameObject b = Instantiate(bullet,head.position, Quaternion.identity);
        b.GetComponent<bulletController>().damage = damage;
        b.GetComponent<Rigidbody>().AddForce(head.forward*shootForce);
    }
    IEnumerator Patrol() 
    {
        for(;;) 
        {
            if(targets.Count>0)
            {
                Shoot();
            yield return new WaitForSeconds(1/attackSpeed);
            }
            yield return null;
        }
    }

    public void stop(){
        StopCoroutine("Patrol");
    }

}
