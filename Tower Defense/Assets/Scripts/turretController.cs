using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    // Start is called before the first frame update
    public int range;
    public float attackSpeed;
    public GameObject bullet;
    public List<GameObject> targets = new List<GameObject>();
    //public Queue<GameObject> targ = new Queue<GameObject>();
    //GameObject currentTarget;
    Transform head;
    void Start()
    {
        head = this.transform.Find("Head");
        StartCoroutine("Patrol");
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag.Contains("Enemy") ){
            //currentTarget = other.gameObject;
            targets.Add(other.gameObject);
            //targ.Enqueue(other.gameObject);
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag.Contains("Enemy")){
            targets.Remove(other.gameObject);
            //targ.Dequeue();
        }
    }
    // Update is called once per frame
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
        b.GetComponent<Rigidbody>().AddForce(head.forward*800);
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

}
