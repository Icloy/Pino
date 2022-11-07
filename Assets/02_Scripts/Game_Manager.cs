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
        //���嵥���Ͱ� �ִٸ� �÷��̾ ������ġ�� �̵�
        if(!(DataManager.instance.nowPlayer.playerPos.x == 0 && DataManager.instance.nowPlayer.playerPos.z == 0))
        {
            player.transform.position = DataManager.instance.nowPlayer.playerPos;
        }

        ResumeGame(); // ���� �÷��̻��·� ����

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
                PauseResumeGame();
                optionMenu.SetActive(false);
            }
            else
            {
                PauseResumeGame();
                optionMenu.SetActive(true);
            }  
                
        }
    }
   
    public void PauseResumeGame() //������ ���� ���θ� ����
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
    public void ResumeGame()
    {
        if(isPause == true)
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
        PauseResumeGame();
    }

    public void OptionOff() //�ɼ� ��ư �ٽ� ������ �� (����)
    {
        OptionBtn.SetActive(false);
        PauseResumeGame();
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
        DataManager.instance.nowPlayer.playerPos = player.transform.position;
        DataManager.instance.SaveData();
    }
}
