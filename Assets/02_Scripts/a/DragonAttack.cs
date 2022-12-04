using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    public Vector3 PickPosition; //���⸦ ������� ��ġ�� ȸ������ ����
    public Vector3 PickRotation;
    public GameObject HellFire;

    public virtual void OnUse()
    {
        transform.localPosition = PickPosition;
        transform.localEulerAngles = PickRotation;
    }
}
