using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetObjectToClick : MonoBehaviour, IPointerClickHandler
{
   [SerializeField] private GeometryObjectData _figureSettings;

    public void OnPointerClick(PointerEventData eventData) {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;      
        if(Physics.Raycast(myRay, out hitInfo, 100))
        {           
            Instantiate(_figureSettings.GetRandomElement().ObjectType, new Vector3(hitInfo.point.x, hitInfo.point.y + 0.5f, hitInfo.point.z), Quaternion.identity); ;
        }
    }  
}
