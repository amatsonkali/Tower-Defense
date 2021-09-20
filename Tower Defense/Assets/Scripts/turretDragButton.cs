using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class turretDragButton : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public GameObject turretPrefab;
    void Start()
    {
        
    }

    public void OnDrag(PointerEventData eventData){
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        transform.localPosition = Vector3.zero;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            if(hit.transform.tag.Contains("Slot") ){
                //mensaje de instanciar algo
                hit.transform.SendMessage("spawnTurret",turretPrefab);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
