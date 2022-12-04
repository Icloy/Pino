using System.Collections;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public AudioClip hitSound; //피격시 재생할 오디오 소스

    public float attackDmg = 0;
    public bool equip = false;

    public static Player_Attack instance;
    private AudioSource AudioPlayer; //오디오 소스 컴포넌트



    private void Awake()
    {
        instance = this;
        AudioPlayer = GetComponent<AudioSource>();

    }


    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Game_EnemyChomper>().HitEnemy(attackDmg);
            AudioPlayer.PlayOneShot(hitSound); // 소리 재생

        }
    }

    private IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
