using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postion : MonoBehaviour
{
    [SerializeField]
    private int health; // ü�¼��� ������Ʈ

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Player_Health.instance.IncDegHp("Hungry", health); // �����, ä���ġ
            ToastMsg.Instance.showMessage("ȸ���Ǿ����ϴ�!", 1.0f); // �޽��� ���
            Destroy(gameObject); // ��������
            
        }
    }


}




