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
        Time.timeScale = 1f; //게임을 항상 시작 상태로 설정
        float LocX = float.Parse(DataManager.instance.nowPlayer.PlayerLocX);    // 게임시작시 좌표 받아와서 플레이어 이동시킴
        float LocZ = float.Parse(DataManager.instance.nowPlayer.PlayerLocZ);
        player.transform.position = new Vector3(LocX, 1.5f, LocZ);
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

    public void PauseGame() //게임의 정지 여부를 관리
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

    public void GameOffBtn() //게임 종료버튼 클릭시
    {
        GameExitPanel.SetActive(true);
    }

    public void OptionOn() //옵션 버튼 눌렀을 때 (켜기)
    {
        OptionBtn.SetActive(true);
        PauseGame();
    }

    public void OptionOff() //옵션 버튼 다시 눌렀을 때 (끄기)
    {
        OptionBtn.SetActive(false);
        PauseGame();
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
        DataManager.instance.nowPlayer.PlayerLocX = player.transform.position.x.ToString();
        DataManager.instance.nowPlayer.PlayerLocZ = player.transform.position.z.ToString();
        DataManager.instance.SaveData();
    }
}
