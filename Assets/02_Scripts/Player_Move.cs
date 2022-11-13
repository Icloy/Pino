using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    float gravity = -20f; //중력
    float yVelocity = 0f; //수직 속력

    CharacterController cc;
    Vector3 moveVec;

    void Start()
    {
        cc = GetComponent<CharacterController>(); //캐릭터 컴포넌트 받아오기
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
