using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P : MonoBehaviour
{
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
}
