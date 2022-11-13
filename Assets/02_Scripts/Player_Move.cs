using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    float gravity = -20f; //�߷�
    float yVelocity = 0f; //���� �ӷ�

    CharacterController cc;
    Vector3 moveVec;

    void Start()
    {
        cc = GetComponent<CharacterController>(); //ĳ���� ������Ʈ �޾ƿ���
    }


    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        yVelocity += gravity * Time.deltaTime;
        moveVec.y = yVelocity;

        cc.Move(moveVec * speed * Time.deltaTime);
    }
}
