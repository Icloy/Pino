using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Boss : MonoBehaviour
{
    public float AttackDistance;
    public float attackDelay;

    public GameObject attackStart;
    public GameObject AttackObject;
    GameObject player;
    Animator anim;

    public float maxHp;
    private float curHp;
    private float curTime;
    private bool isdead;

    enum BossState
    {
        Idle,
        Attack,
        Die
    }
    BossState bossState;

    void Start()
    {
        player = GameObject.Find("Player");
        anim = transform.GetComponentInChildren<Animator>();  //�ڽ����κ��� �ִϸ����� ���� �޾ƿ���
        curHp = maxHp;
    }

    void Update()
    {
        if (!isdead)
        {
            switch (bossState)
            {
                case BossState.Idle:
                    Idle();
                    break;
                case BossState.Attack:
                    Attack();
                    break;
                case BossState.Die:
                    //Die();
                    break;
            }
        }
    }
    void Idle()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < AttackDistance)
        {
            bossState = BossState.Attack;
        }
    }

    void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < AttackDistance)
        {
            curTime += Time.deltaTime;
            if (curTime > attackDelay)
            {
                anim.SetTrigger("IdleToAttack");
                Instantiate(AttackObject, attackStart.transform.position, Quaternion.identity); //����
                curTime = 0f;
            }
        }
        else
        {
            anim.SetTrigger("AttackToIdle");
            bossState = BossState.Idle;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AttackBox")
        {
            if (curHp >= 0)
            {
                curHp -= Player_Attack.instance.attackDmg;

                //AudioPlayer.PlayOneShot(hitSound); //�ǰ� �Ҹ� ���
            }
            else
            {
                Die();
            }
        }
    }

    void Die()
    {
        bossState = BossState.Die;
        isdead = true;
        anim.SetTrigger("Die");
        Destroy(gameObject);
    }

}
