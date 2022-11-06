using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Game_Manager : MonoBehaviour
{
    public GameObject GameExitPanel;
    public GameObject OptionBtn;
    public GameObject player;
    public GameObject optionMenu;
    bool isPause;

    void Start()
    {
        Time.timeScale = 1f; //������ �׻� ���� ���·� ����
        float LocX = float.Parse(DataManager.instance.nowPlayer.PlayerLocX);    // ���ӽ��۽� ��ǥ �޾ƿͼ� �÷��̾� �̵���Ŵ
        float LocZ = float.Parse(DataManager.instance.nowPlayer.PlayerLocZ);
        player.transform.position = new Vector3(LocX, 1.5f, LocZ);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) //esc ��ư���� �ɼǸ޴� ���� �ֵ��� ����
        {
            if(GameExitPanel.activeSelf) // �������� �˾�â�� �������� �� ������ ����
            {
                return;
            }

            if (optionMenu.activeSelf) { 
                PauseGame();
                optionMenu.SetActive(false);
            }
            else
            {
                PauseGame();
                optionMenu.SetActive(true);
            }  
                
        }
    }

    public void PauseGame() //������ ���� ���θ� ����
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void GameOffBtn() //���� �����ư Ŭ����
    {
        GameExitPanel.SetActive(true);
    }

    public void OptionOn() //�ɼ� ��ư ������ �� (�ѱ�)
    {
        OptionBtn.SetActive(true);
        PauseGame();
    }

    public void OptionOff() //�ɼ� ��ư �ٽ� ������ �� (����)
    {
        OptionBtn.SetActive(false);
        PauseGame();
    }

    public void GameExitYes() //���������г� Yes��ư
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void GameExitNo()    //���������г� No��ư
    {
        GameExitPanel.SetActive(false);
    }
    
    public void SaveGame() //���̺� ��ư Ŭ�� ��
    {
        DataManager.instance.nowPlayer.PlayerLocX = player.transform.position.x.ToString();
        DataManager.instance.nowPlayer.PlayerLocZ = player.transform.position.z.ToString();
        DataManager.instance.SaveData();
    }
}
