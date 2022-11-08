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
        //저장데이터가 있다면 플레이어를 저장위치로 이동
        if (!(DataManager.instance.nowPlayer.playerPos.x == 0 && DataManager.instance.nowPlayer.playerPos.z == 0))
        {
            player.transform.position = DataManager.instance.nowPlayer.playerPos;
        }

        ResumeGame(); // 게임 플레이상태로 시작

    }

    void Update()
    {
        if (isPause == false && Input.GetButtonDown("Cancel")) //esc 버튼으로 옵션메뉴 열수 있도록 설정
        {
            if(GameExitPanel.activeSelf) // 게임종료 팝업창이 켜져있을 때 동작을 막음
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

       
        if (Input.GetKeyDown(KeyCode.P)) //P버튼이 눌렸을 경우 
        {
            pauseBtn(); //함수 실행
        }
        

    }
   
    public void PauseResumeGame() //게임의 정지 여부를 관리
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

    public void GameOffBtn() //게임 종료버튼 클릭시
    {
        if (!PausePanel.activeSelf)
        {
            GameExitPanel.SetActive(true);
        }
    }

    public void OptionOn() //옵션 버튼 눌렀을 때 (켜기)
    {
        if (!PausePanel.activeSelf)
        {
            OptionBtn.SetActive(true);
        }
    }

    public void OptionOff() //옵션 버튼 다시 눌렀을 때 (끄기)
    {
        if (!PausePanel.activeSelf)
        {
            OptionBtn.SetActive(false);
        }
    }

    public void GameExitYes() //게임종료패널 Yes버튼
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void GameExitNo()    //게임종료패널 No버튼
    {
        GameExitPanel.SetActive(false);
    }
    
    public void pauseBtn()
    {
        if(isPause == true) //게임이 멈춰 있을 경우
        {
            PausePanel.SetActive(false);
            PauseResumeGame();  //PausePanel을 제거하고 게임 재시작 시킨다.
        }
        else   // 게임이 실행 중일 경우
        {
            PausePanel.SetActive(true);
            PauseResumeGame();  //PausePanel을 불러오고 게임을 멈ㅊ춘다.
        }
    }

    public void SaveGame() //세이브 버튼 클릭 시
    {
        if (isPause == true)
        {
            return;
        }
        DataManager.instance.nowPlayer.playerPos = player.transform.position;
        DataManager.instance.SaveData();
        ToastMsg.Instance.showMessage("저장되었습니다!", 1.0f);
    }
}
