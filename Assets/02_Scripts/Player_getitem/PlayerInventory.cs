using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfMushroom { get; private set; }

    public void MushroomCollected()
    {
        NumberOfMushroom++;
    }
}
