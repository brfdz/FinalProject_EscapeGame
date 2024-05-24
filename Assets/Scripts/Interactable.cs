using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject infoPanel;
    private void OnTriggerEnter(Collider other)
    {
        //Show key press message
        infoPanel.SetActive(true);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interaction(other);
        }
    }

    public abstract void Interaction(Collider other);
   
    
    private void OnTriggerExit(Collider other)
    {
        infoPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}
