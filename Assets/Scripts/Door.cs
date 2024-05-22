using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : Interactable
{
    public int doorID;
    public GameObject wingLeft;
    public GameObject wingRight;

    private Collider doorCollider;
    public TMP_Text message;

    void Start()
    {
        doorCollider = GetComponent<Collider>();
    }

    public override void Interaction(Collider other)
    {
        Dictionary<string, int> playerInv = other.GetComponent<Inventory>().inventory;
        foreach (var pair in playerInv)
        {
            if (pair.Key.Equals("key") && pair.Value.Equals(doorID))
            {
                StartCoroutine(RemoveMessage("Unlocked", 2));
                wingLeft.transform.localRotation = Quaternion.Euler(0, -90, 0);
                wingRight.transform.localRotation = Quaternion.Euler(0, 90, 0);
                
                infoPanel.SetActive(false);

                if (doorCollider != null)
                {
                    doorCollider.enabled = false;
                }
                return;
            }
            
        }
        
        
        StartCoroutine(RemoveMessage("Correct key needed.", 2));
        
        
    }

    IEnumerator RemoveMessage(string mes, float duration)
    {
        message.text = mes;
        yield return new WaitForSeconds(duration);
        message.GetComponent<TMP_Text>().text = "";
    }
    
}
