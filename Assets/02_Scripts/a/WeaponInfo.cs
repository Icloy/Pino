using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponInfo : MonoBehaviour
{
    public GameObject obj1;

    public GameObject obj2;

    public GameObject obj3;

    public GameObject obj4;



    public static WeaponInfo instance;

    private void Awake()
    {
        instance = this;
    }
    public void dropItem(int r, Vector3 trans)
    {
        switch (r)
        {
            case 0:
                Instantiate(obj1, trans, Quaternion.identity); //持失
                break;
            case 1:
                Instantiate(obj2, trans, Quaternion.identity); //持失
                break;
            case 2:
                Instantiate(obj3, trans, Quaternion.identity); //持失
                break;
            case 3:
                Instantiate(obj4, trans, Quaternion.identity); //持失
                break;

            default:
                break;
        }
    }
}
