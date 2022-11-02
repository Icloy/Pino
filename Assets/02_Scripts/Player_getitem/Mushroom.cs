using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.MushroomCollected();
            gameObject.SetActive(false);
        }
    }
    [SerializeField]
    private GameObject go_mushroom_prefab; // 버섯 아이템
}
