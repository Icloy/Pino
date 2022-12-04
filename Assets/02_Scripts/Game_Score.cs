using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Game_Score : MonoBehaviour // ���� ���� ������ ȯ���ϴ� ���ھ� ����
{
    public Text GameOverText;
    public Text nowusername;
    public float totalScore; // �� ����
    public int killCnt = 1; //���� ���� ��
    public int dayCnt; //���ڰ� ���� ��

    public static Game_Score instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        dayCnt = Game_Time.instance.date; // ���� ������ ���� ���� ���� �޾ƿ���
    }

    void Update()
    {

    }
    public void PrintScore() //���� ���
    {
        totalScore = (killCnt * 1.2f) * (dayCnt * 1.2f);
        GameOverText.text = "���� : " + (int)totalScore;
        nowusername.text = "�̸� : " + DataManager.instance.nowPlayer.UserName;
    }


}