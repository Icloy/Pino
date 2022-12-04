using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemInfo : MonoBehaviour
{
    public GameObject gum1;

    public GameObject gum2;

    public GameObject gum3;


    public static CItemInfo instance;

    private void Awake()
    {
        instance = this;
    }
    public void dropItem(int r, Vector3 trans)
    {
        switch (r)
        {
            case 0:
                Instantiate(gum1, trans, Quaternion.identity); //持失
                break;
            case 1:
                
                break;
            case 2:
                Instantiate(gum3, trans, Quaternion.identity); //持失
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                Instantiate(gum2, trans, Quaternion.identity); //持失
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
                break;
            case 16:
                break;
            case 17:
                Instantiate(gum1, trans, Quaternion.identity); //持失
                break;
            case 18:
                break;
            case 19:
                break;
            case 20:
                break;
           


            default:
                break;
        }
    }
}
