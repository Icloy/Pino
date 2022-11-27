using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���ӿ����� �ð��� ���� �ϴ� ��ũ��Ʈ 
public class Game_Time : MonoBehaviour
{

    public Text dateText; //����� �ؽ�Ʈ
    public int date; // ���� ���� ����
    public float goalDayTime; // ���� ��ȯ�� ��ǥ ��
    public float curDayTime; // ���� �ð��� ������ų ����

    private int wave = 1;

    public static Game_Time instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (!(DataManager.instance.nowPlayer.Date.Equals(date)&& DataManager.instance.nowPlayer.curTime.Equals(curDayTime))) //�ð��� �ʱⰪ�� �ƴҰ�� ���尪 �ҷ��ͼ� ������ �ֱ�
        {
            date = DataManager.instance.nowPlayer.Date;
            curDayTime = DataManager.instance.nowPlayer.curTime;
            dateText.text = "Day " + date; // �ؽ�Ʈ ȭ�� ���
        }
    }


    void Update()
    {
        //���� �ð��� ���� ���ڸ� �ø�
        curDayTime += Time.deltaTime;
        if (curDayTime > goalDayTime)
        {
            date++; //���� �ø�
            if (date % 3 == 0)
            {
                spawnEnemy();
            }
            Game_Score.instance.dayCnt++; // ������ ������ ���� �ø�
            dateText.text = "Day " + date; // �ؽ�Ʈ ȭ�� ���
            curDayTime = 0f; // �ð� ������ �ʱ�ȭ
        }
    }

    void spawnEnemy()
    {
        for (int i = 1; i >= wave; i++)
        {
            Game_SpawnEnemy.instance.CreateEnemy();
        }
    }
}
