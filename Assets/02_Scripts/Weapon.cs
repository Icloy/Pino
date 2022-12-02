using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Dmg;
    public float attackDmg = 0;
    public bool equip = false;

    public static Weapon instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            equip = true;
            attackDmg = Dmg;
        }    
    }

    private void OnDisable() //오브젝트가 꺼질때 
    {
        attackDmg = 0;      
        equip = false;
    }
}
