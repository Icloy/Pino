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
        //저장데이터가 있다면 플레이어를 저장위치로 이동
        if(!(DataManager.instance.nowPlayer.playerPos.x == 0 && DataManager.instance.nowPlayer.playerPos.z == 0))
        {
            player.transform.position = DataManager.instance.nowPlayer.playerPos;
        }

        ResumeGame(); // 게임 플레이상태로 시작

    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) //esc 버튼으로 옵션메뉴 열수 있도록 설정
        {
            if(GameExitPanel.activeSelf) // 게임종료 팝업창이 켜져있을 때 동작을 막음
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
        GameExitPanel.SetActive(true);
    }

    public void OptionOn() //옵션 버튼 눌렀을 때 (켜기)
    {
        OptionBtn.SetActive(true);
        PauseResumeGame();
    }

    public void OptionOff() //옵션 버튼 다시 눌렀을 때 (끄기)
    {
        OptionBtn.SetActive(false);
        PauseResumeGame();
    }

    public void GameExitYes() //게임종료패널 Yes버튼
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void GameExitNo()    //게임종료패널 No버튼
    {
        GameExitPanel.SetActive(false);
    }
    
    public void SaveGame() //세이브 버튼 클릭 시
    {
        DataManager.instance.nowPlayer.playerPos = player.transform.position;
        DataManager.instance.SaveData();
    }
}
