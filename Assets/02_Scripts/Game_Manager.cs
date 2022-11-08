using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor.VersionControl;

public class Game_Manager : MonoBehaviour
{
    public GameObject GameExitPanel;
    public GameObject OptionBtn;
    public GameObject player;
    public GameObject optionMenu;
    public GameObject PausePanel;
    public GameObject PauseBtn;
    bool isPause;

    void Start()
    {
        //���嵥���Ͱ� �ִٸ� �÷��̾ ������ġ�� �̵�
        if (!(DataManager.instance.nowPlayer.playerPos.x == 0 && DataManager.instance.nowPlayer.playerPos.z == 0))
        {
            player.transform.position = DataManager.instance.nowPlayer.playerPos;
        }

        ResumeGame(); // ���� �÷��̻��·� ����

    }

    void Update()
    {
        if (isPause == false && Input.GetButtonDown("Cancel")) //esc ��ư���� �ɼǸ޴� ���� �ֵ��� ����
        {
            if(GameExitPanel.activeSelf) // �������� �˾�â�� �������� �� ������ ����
            {
                return;
            }

            if (optionMenu.activeSelf) {
                optionMenu.SetActive(false);
            }
            else
            {
                optionMenu.SetActive(true);
            }  
        }

       
        if (Input.GetKeyDown(KeyCode.P)) //P��ư�� ������ ��� 
        {
            pauseBtn(); //�Լ� ����
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
        if (!PausePanel.activeSelf)
        {
            GameExitPanel.SetActive(true);
        }
    }

    public void OptionOn() //�ɼ� ��ư ������ �� (�ѱ�)
    {
        if (!PausePanel.activeSelf)
        {
            OptionBtn.SetActive(true);
        }
    }

    public void OptionOff() //�ɼ� ��ư �ٽ� ������ �� (����)
    {
        if (!PausePanel.activeSelf)
        {
            OptionBtn.SetActive(false);
        }
    }

    public void GameExitYes() //���������г� Yes��ư
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void GameExitNo()    //���������г� No��ư
    {
        GameExitPanel.SetActive(false);
    }
    
    public void pauseBtn()
    {
        if(isPause == true) //������ ���� ���� ���
        {
            PausePanel.SetActive(false);
            PauseResumeGame();  //PausePanel�� �����ϰ� ���� ����� ��Ų��.
        }
        else   // ������ ���� ���� ���
        {
            PausePanel.SetActive(true);
            PauseResumeGame();  //PausePanel�� �ҷ����� ������ �ؤ����.
        }
    }

    public void SaveGame() //���̺� ��ư Ŭ�� ��
    {
        if (isPause == true)
        {
            return;
        }
        DataManager.instance.nowPlayer.playerPos = player.transform.position;
        DataManager.instance.SaveData();
        ToastMsg.Instance.showMessage("����Ǿ����ϴ�!", 1.0f);
    }
}
