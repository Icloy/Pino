using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //패널들을 입력받는다.
    public GameObject OptionPanel;
    public GameObject RankingPanel;
    public GameObject StartGamePanel;

    //게임씬 불러오기
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    //게임 종료 버튼 처리
    public void QuitGame()
    {
        Application.Quit();
    }

    //옵션 버튼 처리
    public void Option()
    {
        OptionPanel.SetActive(true);
    }

    //옵션 패널 종료
    public void OptionPanelOfff()
    {
        OptionPanel.SetActive(false);
    }

    //게임 시작 버튼 처리
    public void GameStart()
    {
        StartGamePanel.SetActive(true);
    }

    //게임시작패널 종료
    public void StartGamePanelOff()
    {
        StartGamePanel.SetActive(false);
    }

    //랭킹 패널 처리
    public void Ranking()
    {
        RankingPanel.SetActive(true);
    }

    //랭킹 패널 종료
    public void RankingPanelOff()
    {
        RankingPanel.SetActive(false);
    }
}
