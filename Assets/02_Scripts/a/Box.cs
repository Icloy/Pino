using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Box : MonoBehaviour
{
    public AudioClip hitSound; //�ǰݽ� ����� ����� �ҽ�

    public float curHealth = 20f; //����ü��

    private bool isdead;
    Animator anim;
    private Animator boxAnimator; //�ִϸ����� ������Ʈ
    private AudioSource AudioPlayer; //����� �ҽ� ������Ʈ

    enum BoxState
    {
        Damaged
    }
    BoxState boxState;

    private void Start()
    { 
        AudioPlayer = GetComponent<AudioSource>();
        anim = transform.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (!isdead)
        {
            switch (boxState)
            {
                case BoxState.Damaged:
                    //Damaged();
                    break;

            }
        }
    }

    /*private void Damaged(float hitPower)
    {
        AudioPlayer.PlayOneShot(hitSound); //�ǰ� �Ҹ� ���
        curHealth -= hitPower; //�� ������ó��
        if (curHealth > 0)
        {
            Debug.Log("�ڽ��ǰ�");
        }
        else
        {
            Die();
        }

    }*/

    void Die()
    {
        StopAllCoroutines(); //�������� �ǰ����� ��� ����

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        isdead = true;
        AudioPlayer.PlayOneShot(hitSound); //��� �Ҹ� ���
        Game_Score.instance.killCnt++; //������ ųī��Ʈ �߰�
        yield return new WaitForSeconds(0.3f); // n�� ����� �ڱ��ڽ� ����
        RandomSel();
        Destroy(gameObject);
    }

    void RandomSel()
    {
        int r = Random.Range(0, 3);
        ItemInfo.instance.dropItem(r, this.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AttackBox")
        {
            if (curHealth > 0)
            {
                curHealth -= Player_Attack.instance.attackDmg;

                AudioPlayer.PlayOneShot(hitSound); //�ǰ� �Ҹ� ���

            }
            else
            {
                Die();
            }

        }
    }
}
