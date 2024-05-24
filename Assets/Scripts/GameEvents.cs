using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
  public static GameEvents Instance { get; private set; }

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else if (Instance != this )
    {
      Destroy(gameObject);
    }
  }

  public event Action<int> OnUnlockDoor;

  public void UnlockDoor(int id)
  {
    if (OnUnlockDoor != null)
    {
      OnUnlockDoor(id);
    }
  }
  
}
