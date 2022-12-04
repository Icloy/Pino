using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;


public class water : MonoBehaviour
{
    float curtime = 0;
    float maxtime = 10;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            curtime += Time.deltaTime;
            if (curtime >= maxtime)
            {
                Player_Health.instance.IncDegHp("Water", 100);
                curtime = 0;
                MiddleToastMsg.Instance.showMessage("수분을 보충했습니다.", 0.7f);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        curtime = 0;
    }
}
