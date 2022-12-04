using System.Collections;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public float attackDmg = 0;
    public bool equip = false;

    public static Player_Attack instance;


    private void Awake()
    {
        instance = this;
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
        }
    }

    private IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
