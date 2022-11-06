using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Option_menu : MonoBehaviour
{
    //옵션메뉴 오브젝트 가져오기
    public GameObject OptionBtn;
    //게임종료 패널 오브젝트 가져오기
    public GameObject GameExitPanel;
    //게임이 정지되었는지 확인하는 열거형 타입변수 제작
    bool isPause = false;

    //메인메뉴씬 불러오기
    public void GameOffBtn()
    {
        GameExitPanel.SetActive(true);
    }

    //옵션 버튼 눌렀을 때 (켜기)
    public void OptionOn()
    {
        OptionBtn.SetActive(true);
        PauseGame();
    }

    //옵션 버튼 다시 눌렀을 때 (끄기)
    public void OptionOff()
    {
        OptionBtn.SetActive(false);
        PauseGame();
    }

    //게임종료패널 Yes버튼
    public void GameExitYes()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    //게임종료패널 No버튼
    public void GameExitNo()
    {
        GameExitPanel.SetActive(false);
    }


    public void PauseGame()
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
}
