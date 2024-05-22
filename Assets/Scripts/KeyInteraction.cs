using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class KeyInteraction : Interactable
{
    
    public int keyID;

    private void Start()
    {
        infoPanel.GetComponentInChildren<TMP_Text>().text = "Press [ E ]";
    }


    public override void Interaction(Collider other)
    {
        //Inventory.InventoryItem myKey = new Inventory.InventoryItem("key", keyID);
        other.GetComponent<Inventory>().inventory.Add("key", keyID);
        Destroy(gameObject);
       
    }
}
