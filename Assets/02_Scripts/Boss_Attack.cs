using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    private Vector3 playertrans;

    public float fireDamage;
    public float fireSpeed;

    private float curTime = 0f;
    private float maxTime = 5f;

    private void Awake()
    {
        playertrans = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(gameObject.transform.position, playertrans, fireSpeed);
        curTime += Time.deltaTime;
        if(curTime > maxTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Health.instance.IncDegHp("Hungry", -fireDamage);
            Destroy(gameObject);
        }
    }
}
