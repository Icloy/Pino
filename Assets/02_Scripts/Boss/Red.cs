using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    public float AttackDistance;
    public float attackDelay;
    public AudioClip deathSound; //����� ����� ����� �ҽ�
    public AudioClip hitSound; //�ǰݽ� ����� ����� �ҽ�
    public AudioClip attackSound;


    private AudioSource AudioPlayer; //����� �ҽ� ������Ʈ


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
    private void Awake()
    {
       AudioPlayer = GetComponent<AudioSource>();

    }

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
                AudioPlayer.PlayOneShot(attackSound); //�ǰ� �Ҹ� ���


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

               AudioPlayer.PlayOneShot(hitSound); //�ǰ� �Ҹ� ���
            }
            else
            {
                Die();
            }
        }
    }

    void Die()
    {
        
        StopAllCoroutines();
        anim.SetTrigger("Die");//�������� �ǰ����� ��� ����
        StartCoroutine(DieProcess());
        

    }

    IEnumerator DieProcess()
    {
        bossState = BossState.Die;
        isdead = true;
        AudioPlayer.PlayOneShot(deathSound); //��� �Ҹ� ���
        Game_Score.instance.killCnt+= 10; //������ ųī��Ʈ �߰�
        yield return new WaitForSeconds(2f); // n�� ����� �ڱ��ڽ� ����
        RandomSel();
        Destroy(gameObject);
        if (isdead)
        {
            Game_Manager.instance.bossKillCnt++;
            
        }
    }

    void RandomSel()
    {

        WeaponInfo.instance.dropItem(0, this.transform.position);
    }
}
