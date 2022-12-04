using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    public Vector3 PickPosition; //무기를 들었을때 위치와 회전도를 정의
    public Vector3 PickRotation;
    public GameObject HellFire;

    public virtual void OnUse()
    {
        transform.localPosition = PickPosition;
        transform.localEulerAngles = PickRotation;
    }
}
