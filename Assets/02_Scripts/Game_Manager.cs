using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Game_Manager : MonoBehaviour
{
    public GameObject GameExitPanel;
    public GameObject GameOverPanel;
    public GameObject GameSoundPanel;
    public GameObject OptionBtn;
    public GameObject player;
    public GameObject optionMenu;
    public GameObject PausePanel;
    bool isPause;

    public static Game_Manager instance;

    public int bossKillCnt = 1;
    public Text GameOC;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        GameOverPanel.SetActive(false);

       if (!(DataManager.instance.nowPlayer.playerPos.x == 10 && DataManager.instance.nowPlayer.playerPos.z == 4))
        {
            player.transform.position = DataManager.instance.nowPlayer.playerPos;
        }

        if (DataManager.instance.nowPlayer.chomPos.Length != 0) //�ʵ忡 ���� ���尪���ִٸ�.
        {
            for (int i = 0; i < DataManager.instance.nowPlayer.chomPos.Length; i++) //wave�� ����ŭ �ݺ��� ����
            {
                Instantiate(Game_SpawnEnemy.instance.Enemy, DataManager.instance.nowPlayer.chomPos[i], Quaternion.identity); //����
            }
        }
        
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

        if(bossKillCnt == 5)
        {
            ClearGame();
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

    public void GameOffBtn() //���� �����ư Ŭ����
    {
        if (!PausePanel.activeSelf)
        {
            GameExitPanel.SetActive(true);
        }
    }

    public void Option() //�ɼ� ��ư ������ �� (�ѱ�)
    {
        if (!PausePanel.activeSelf)
        {
            if (OptionBtn.activeSelf)
            {
                OptionBtn.SetActive(false);
            }
            else
            {
                OptionBtn.SetActive(true);
            }
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
            PauseResumeGame();  //PausePanel�� �ҷ����� ������ �����.
        }
    }

    public void soundBtn()
    {
        if (!PausePanel.activeSelf)
        {
            if (!GameSoundPanel.activeSelf)
            {
                GameSoundPanel.SetActive(true);
                PauseResumeGame();
            }
            else
            {
                GameSoundPanel.SetActive(false);
                PauseResumeGame();
            }
        }
    }
    public void SaveGame() //���̺� ��ư Ŭ�� ��
    {
        if (isPause == true)
        {
            return;
        }
        DataManager.instance.nowPlayer.playerPos = player.transform.position;
        DataManager.instance.nowPlayer.MentalHp = Player_Health.instance.MentalCurrentHp;
        DataManager.instance.nowPlayer.WaterHp = Player_Health.instance.WaterCurrentHp;
        DataManager.instance.nowPlayer.HungryHp = Player_Health.instance.HungryCurrentHp;
        DataManager.instance.nowPlayer.curTime = Game_Time.instance.curDayTime;
        DataManager.instance.nowPlayer.Date = Game_Time.instance.date;
        GameObject [] chompPos = GameObject.FindGameObjectsWithTag("Enemy");
        DataManager.instance.nowPlayer.chomPos = new Vector3[chompPos.Length];
        for (int i = 0; i < chompPos.Length; i++)
        {
            print(chompPos[i].transform.position);
            DataManager.instance.nowPlayer.chomPos[i] = chompPos[i].transform.position;
        }
        DataManager.instance.SaveData();
        ToastMsg.Instance.showMessage("����Ǿ����ϴ�!", 1.0f);
    }

    public void GameOver() //���� ����ó��
    {
        GameOverPanel.SetActive(true);
        GameOC.text = "Game Over";
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Game_Score.instance.PrintScore();
    }

    public void GameOverBtn() //���ӿ��� ��ư Ŭ����
    {
        print("��ư Ŭ��");
        addScore.instance.SendScoreBtn();
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("Main_Scene");
    }

    public void ClearGame()
    {
        GameOverPanel.SetActive(true);
        GameOC.text = "Game Clear";
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Game_Score.instance.PrintScore();
    }
}
