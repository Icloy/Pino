using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{

    //슬라이더를 받기
    public Slider HungrySlider;
    public Slider WaterSlider;
    public Slider MentalSlider;

    public float dotTime; //플레이어가 지속적으로 피해를 입는 시간
    float timeSpan;  //시간을 누적 시킬 값
    public float MentalMaxHp;
    public float MentalCurrentHp;
    public float WaterMaxHp;
    public float WaterCurrentHp;
    public float HungryMaxHp;
    public float HungryCurrentHp;


    public static Player_Health instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeSpan = 0f;
        if(!(DataManager.instance.nowPlayer.MentalHp == 100f && DataManager.instance.nowPlayer.WaterHp == 100f && DataManager.instance.nowPlayer.HungryHp == 100f))
        {
            MentalCurrentHp = DataManager.instance.nowPlayer.MentalHp;
            WaterCurrentHp = DataManager.instance.nowPlayer.WaterHp;
            HungryCurrentHp = DataManager.instance.nowPlayer.HungryHp;
        }
    }

    void Update()
    {
        //hp를 체력바로 변환
        MentalSlider.value = MentalCurrentHp / MentalMaxHp;
        WaterSlider.value = WaterCurrentHp / WaterMaxHp;
        HungrySlider.value = HungryCurrentHp / HungryMaxHp;

        //hp가 0보다 아래로 내려가면
        if (MentalCurrentHp <= 0)
        {
            Game_Manager.instance.GameOver(); // 게임 오버처리
        }

        timeSpan += Time.deltaTime;  // 경과 시간을 timeSpan에 누적
        if (timeSpan > dotTime)  // 경과 시간이 특정 시간이 보다 커졋을 경우 플레이어의 Hp를 감소시킨다.
        {
            DigHp("Mental", 5);
            timeSpan = 0; //timespan값을 초기화 시킨다.
        }
    }

    public void DigHp(string HpName, float HpValue) //플레이어 체력 감소 처리
    {
        switch (HpName)
        {
            case "Mental" :
                MentalCurrentHp -= HpValue;
                break;
            case "Water":
                WaterCurrentHp -= HpValue;
                break;
            case "Hungry":
                HungryCurrentHp -= HpValue;
                break;
        }
    }

    public void IncHp()  //플레이어 체력 회복 처리
    {

    }
}
