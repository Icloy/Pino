using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Dmg;

    public static Weapon instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Attack.instance.equip = true;
            Player_Attack.instance.attackDmg = Dmg;
        }
    }

    private void OnDisable() //오브젝트가 꺼질때 
    {
        Player_Attack.instance.attackDmg = 0;
        Player_Attack.instance.equip = false;
    }
}
