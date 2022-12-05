using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    

    public float speed;
    float hAxis;
    float vAxis;
    //float gravity = -20f; //중력
    //float yVelocity = 0f; //수직 속력

    CharacterController cc;
    Vector3 moveVec;

    Animator anim;

    [SerializeField]
    private GameObject AttackBox;

    


    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        cc = GetComponent<CharacterController>(); //캐릭터 컴포넌트 받아오기
        

    }


    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        cc.Move(moveVec * speed * Time.deltaTime);
        
        anim.SetBool("IdleToMove", moveVec != Vector3.zero);

        transform.LookAt(transform.position + moveVec);

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ComboAttack();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if(Player_Health.instance.WaterCurrentHp > 10)
            {
                speed = 50;
                curTime += Time.deltaTime;
                if (curTime > maxTime)
                {
                    Player_Health.instance.WaterCurrentHp -= 5;
                    curTime = 0;
                }
                
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 12;
        }
    }
    private float curTime = 0f;
    private float maxTime = 3f;
    public void Attack()
    {
        anim.SetTrigger("Attack");

    }

    public void ComboAttack()
    {
        anim.SetTrigger("ComboAttack");
    }

    public void OnAttackBox()
    {
        AttackBox.SetActive(true);
    }
    
}
