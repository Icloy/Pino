using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemInfo : MonoBehaviour
{
    public GameObject ManaPosion;

    public GameObject EnduPosion;

    public GameObject HealthPosion;

    public GameObject obj4;

    public GameObject obj5;

    public GameObject obj6;

    public static ItemInfo instance;

    private void Awake()
    {
        instance = this;
    }
    public void dropItem(int r, Vector3 trans)
    {
        switch (r)
        {
            case 0:
                Instantiate(ManaPosion, trans, Quaternion.identity); //持失
                break;
            case 1:
                Instantiate(EnduPosion, trans, Quaternion.identity); //持失
                break;
            case 2:
                Instantiate(HealthPosion, trans, Quaternion.identity); //持失
                break;
            default:
                break;
        }
    }
}
