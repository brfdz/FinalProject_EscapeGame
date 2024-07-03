using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : Interactable
{
    public GameObject wing;
    private float angle;
    private bool open;
    void Start()
    {
        open = false;
    }
    
    
    public override void Interaction(Collider other)
    {
        angle = open ? 0 : -90;
        open = !open;
        wing.transform.localRotation = Quaternion.Euler(0, angle, 0);
        //close interaction message "press[E]"
        infoPanel.SetActive(false);
        
    }
}
