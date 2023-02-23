using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectClick : MonoBehaviour
{
    public Text outp;
    public Material selected;
    public Material unselected;
    private GameObject prevSelected;
    public Transform hitChild;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
             
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {   
                if (outp.text != "") 
                {
                    prevSelected.transform.GetComponent<MeshRenderer>().material = unselected;
                }   
                if (hit.transform.name.Length != 0) {  
                    outp.text = hit.transform.name;
                    hit.transform.GetComponent<MeshRenderer>().material = selected;
                    for (int i = 0; i < hit.transform.childCount; i++) 
                    {
                        hitChild = hit.transform.GetChild(i);
                        hitChild.transform.GetComponent<MeshRenderer>().material = selected;
                    }
                    prevSelected = hit.transform.gameObject;   
                }      
            }  
        }  
    }
}