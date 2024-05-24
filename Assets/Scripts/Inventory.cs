using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> inventory;
    
    public struct InventoryItem
    {
        public string name;
        public int id;

        public InventoryItem(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
        
    }


    private void Start()
    {
        inventory = new Dictionary<string, int>();
    }
}
