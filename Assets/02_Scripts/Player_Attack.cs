using System.Collections;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{ 
    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Game_EnemyChomper>().HitEnemy(Weapon.instance.attackDmg);
        }
    }

    private IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }



}
