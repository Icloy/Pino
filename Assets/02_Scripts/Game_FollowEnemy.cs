using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_FollowEnemy : MonoBehaviour
{
    CharacterController cc;
    Transform player;   //�÷��̾� ��ǥ
    Vector3 originPos; //���� �ʱ���ǥ

    public float attackDistance = 2.5f; //���ݹ���
    public float moveSpeed = 2f; //�̵��ӵ�
    public float attackPower = 3f; //���� ���� ������
    public float enemyHp = 50f; //���� ���� ü��
    public float enemyMaxHp = 50f; //���� �ִ� ü��
    float attackcurTime = 0f;  //���ݽð� ���� ����
    float attackDelay = 2f;  //���� ������ �ð�

    Animator anim;

    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Damaged,
        Die
    }

    EnemyState enemyState;

    private void Start()
    {
        enemyState = EnemyState.Idle; //�ʱ� ���� ��� ����
        attackcurTime = attackDelay; //����ÿ��� �ٷ� �����ϵ���
        player = GameObject.Find("Player").transform; //�÷��̾� ��ǥ �޾ƿ���
        cc = GetComponent<CharacterController>(); //ĳ���� ������Ʈ �޾ƿ���
        originPos = transform.position;

        anim = transform.GetComponentInChildren<Animator>();  //�ڽ����κ��� �ִϸ����� ���� �޾ƿ���
    }

    private void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
        }
    }

    void Idle() //��� ����
    {
        enemyState = EnemyState.Move; //��� ��ȯ
        anim.SetTrigger("IdleToMove"); //�̵� �ִϸ��̼����� ��ȯ
    }

    void Move() //�̵�����
    {
        if (Vector3.Distance(transform.position, player.position) > attackDistance) //���ݹ��� ���̶��
        {
            Vector3 dir = (player.position - transform.position).normalized; //���⼳��
            cc.Move(dir * moveSpeed * Time.deltaTime); //�̵�

            transform.forward = dir; //�÷��̾ ���� ������ ��ȯ�Ѵ�.
        }
        else //���ݹ��� ���̶��
        {
            enemyState = EnemyState.Attack; //�� ���� ���·� �ٲ�
            anim.SetTrigger("MoveToAttackdelay");//���� ��� �ִϸ��̼�
        }


    }

    void Attack() //����
    {
        attackcurTime += Time.deltaTime; //������ �ð�����
        if (Vector3.Distance(transform.position, player.position) < attackDistance)  //���ݹ��� ���̶��
        {
            if (attackcurTime > attackDelay) // �ð��� �Ǿ��ٸ�
            {
                Player_Health.instance.IncDegHp("Hungry", -attackPower); //������ ó����
                print("����");
                attackcurTime = 0f; //�ð� �ʱ�ȭ
                anim.SetTrigger("StartAttack"); //���� �ִϸ��̼�
            }

        }
        else //���ݹ��� ���̶��
        {
            enemyState = EnemyState.Move; //�÷��̾� ���߰�
            anim.SetTrigger("AttackToMove"); //�̵� �ִϸ��̼�
            attackcurTime = 0f; //�ð� �ʱ�ȭ
        }

    }

    void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.3f) //�ʱ���ǥ�� �̵����� ������ �ִٸ�
        {
            Vector3 dir = (originPos - transform.position).normalized; //���⼳��
            cc.Move(dir * moveSpeed * Time.deltaTime); //�̵�

            transform.forward = dir; //������ ���͹����� ���ϵ��� �Ѵ�.
        }
        else
        {
            transform.position = originPos;
            enemyHp = enemyMaxHp; //ü��ȸ��
            attackcurTime = attackDelay; //����ÿ��� �ٷ� �����ϵ���
            enemyState = EnemyState.Idle; //�����·� ��ȯ
            anim.SetTrigger("MoveToIdle"); //��� �ִϸ��̼����� ��ȯ
        }
    }

    public void HitEnemy(float hitPower) //���� ���� �޾��� �� ü�� ���� �Լ�
    {
        if (enemyState == EnemyState.Damaged || enemyState == EnemyState.Die)
        {
            return; //�̹� �ǰݵǰ��ְų� ����Ǵ� ���ͻ����ϰ�� �Լ��� �����Ѵ�.
        }

        enemyHp -= hitPower; //�� ������ó��

        if (enemyHp > 0)
        {
            enemyState = EnemyState.Damaged; // ���� ��ȯ
            anim.SetTrigger("Damaged"); //�ִϸ��̼� ����
            Damaged();
        }
        else
        {
            enemyState = EnemyState.Die; //���� ��ȯ
            anim.SetTrigger("Die"); //�ִϸ��̼� ����
            Die();
        }
    }

    void Damaged()
    {
        StartCoroutine(DamageProcess()); //�ڷ�ƾ�Լ� ����
    }

    void Die()
    {
        StopAllCoroutines(); //�������� �ǰ����� ��� ����

        StartCoroutine(DieProcess());
    }


    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f); //�ǰ� ��� �ð���ŭ ���
        enemyState = EnemyState.Move; //�̵����·� ��ȯ
    }

    IEnumerator DieProcess()
    {
        Game_Score.instance.killCnt++; //������ ųī��Ʈ �߰�
        cc.enabled = false; //cc�� ��Ȱ��ȭ
        yield return new WaitForSeconds(1f); // 1�� ����� �ڱ��ڽ� ����
        Destroy(gameObject);
    }
}