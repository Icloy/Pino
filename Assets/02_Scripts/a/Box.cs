using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Box : MonoBehaviour
{
    public AudioClip hitSound; //피격시 재생할 오디오 소스

    public float curHealth = 20f; //현재체력

    private bool isdead;
    Animator anim;
    private Animator boxAnimator; //애니메이터 컴포넌트
    private AudioSource AudioPlayer; //오디오 소스 컴포넌트

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
        AudioPlayer.PlayOneShot(hitSound); //피격 소리 재생
        curHealth -= hitPower; //적 데미지처리
        if (curHealth > 0)
        {
            Debug.Log("박스피격");
        }
        else
        {
            Die();
        }

    }*/

    void Die()
    {
        StopAllCoroutines(); //진행중인 피격판정 모두 종료

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        isdead = true;
        AudioPlayer.PlayOneShot(hitSound); //사망 소리 재생
        Game_Score.instance.killCnt++; //점수용 킬카운트 추가
        yield return new WaitForSeconds(0.3f); // n초 대기후 자기자신 제거
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

                AudioPlayer.PlayOneShot(hitSound); //피격 소리 재생

            }
            else
            {
                Die();
            }

        }
    }
}
