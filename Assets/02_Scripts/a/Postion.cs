using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postion : MonoBehaviour
{
    [SerializeField]
    private int health; // 체력설정 컴포넌트

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Player_Health.instance.IncDegHp("Hungry", health); // 허기짐, 채울수치
            ToastMsg.Instance.showMessage("회복되었습니다!", 1.0f); // 메시지 출력
            Destroy(gameObject); // 옵젝삭제
            
        }
    }


}




