using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class PlayerData // �����͸� ������ Ŭ����
{
    public string UserName;
    public int HungryHp;
    public int WaterHp;
    public int MentalHp;
    public string PlayerLocX;
    public string PlayerLocZ;
}



public class DataManager : MonoBehaviour
{
    public static DataManager instance; //�̱���

    public PlayerData nowPlayer = new PlayerData();

    public string path; // ������ ���� ����
    public int nowSlot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/"; //����Ƽ ���� �⺻��η� ��� ����
    }

    
    void Start()
    {
        
    }

    public void SaveData() //Json �������� ����
    {
        string data = JsonUtility.ToJson(nowPlayer); 
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData() 
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }
    
    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}
