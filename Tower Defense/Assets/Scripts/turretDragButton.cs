using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class turretDragButton : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject turretPrefab;

    public void OnDrag(PointerEventData eventData){
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        transform.localPosition = Vector3.zero;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            if(hit.transform.tag.Contains("Slot") ){
                hit.transform.SendMessage("spawnTurret",turretPrefab);
            }
        }
    }
}
