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
    private bool isUnlocked;

    void Start()
    {
        doorCollider = GetComponent<Collider>();
        GameEvents.Instance.OnUnlockDoor += UnlockDoor;
    }

    private void UnlockDoor(int id)
    {
        if (id == doorID)
        {
            isUnlocked = true;
        }
    }

    public override void Interaction(Collider other)
    {
        if (isUnlocked)
        {
            //show Unlocked message and open door
            StartCoroutine(RemoveMessage("Unlocked", 2));
            wingLeft.transform.localRotation = Quaternion.Euler(0, -90, 0);
            wingRight.transform.localRotation = Quaternion.Euler(0, 90, 0);
            
            //close interaction message "press[E]"
            infoPanel.SetActive(false);

            //disable door interaction
            if (doorCollider != null)
            {
                doorCollider.enabled = false;
            }
            return;
        }
        
        //when door is still locked
        StartCoroutine(RemoveMessage("Correct key needed.", 2));
        
    }

    //Delete message from screen after given seconds
    IEnumerator RemoveMessage(string mes, float duration)
    {
        message.text = mes;
        yield return new WaitForSeconds(duration);
        message.GetComponent<TMP_Text>().text = "";
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnUnlockDoor -= UnlockDoor;
    }
}
