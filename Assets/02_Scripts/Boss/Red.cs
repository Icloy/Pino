using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    public float AttackDistance;
    public float attackDelay;
    public AudioClip deathSound; //사망시 재생할 오디오 소스
    public AudioClip hitSound; //피격시 재생할 오디오 소스
    public AudioClip attackSound;


    private AudioSource AudioPlayer; //오디오 소스 컴포넌트


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
        anim = transform.GetComponentInChildren<Animator>();  //자식으로부터 애니메이터 변수 받아오기
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
                AudioPlayer.PlayOneShot(attackSound); //피격 소리 재생


                Instantiate(AttackObject, attackStart.transform.position, Quaternion.identity); //생성
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

               AudioPlayer.PlayOneShot(hitSound); //피격 소리 재생
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
        anim.SetTrigger("Die");//진행중인 피격판정 모두 종료
        StartCoroutine(DieProcess());
        

    }

    IEnumerator DieProcess()
    {
        bossState = BossState.Die;
        isdead = true;
        AudioPlayer.PlayOneShot(deathSound); //사망 소리 재생
        Game_Score.instance.killCnt+= 10; //점수용 킬카운트 추가
        yield return new WaitForSeconds(2f); // n초 대기후 자기자신 제거
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
