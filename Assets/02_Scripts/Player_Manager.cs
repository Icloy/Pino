using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    //float gravity = -20f; //�߷�
    //float yVelocity = 0f; //���� �ӷ�

    CharacterController cc;
    Vector3 moveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        cc = GetComponent<CharacterController>(); //ĳ���� ������Ʈ �޾ƿ���
    }


    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        cc.Move(moveVec * speed * Time.deltaTime);
        
        anim.SetBool("IdleToMove", moveVec != Vector3.zero);

        transform.LookAt(transform.position + moveVec);
    }
}
