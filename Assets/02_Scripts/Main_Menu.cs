using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //�гε��� �Է¹޴´�.
    public GameObject OptionPanel;
    public GameObject RankingPanel;
    public GameObject StartGamePanel;

    //���Ӿ� �ҷ�����
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    //���� ���� ��ư ó��
    public void QuitGame()
    {
        Application.Quit();
    }

    //�ɼ� ��ư ó��
    public void Option()
    {
        OptionPanel.SetActive(true);
    }

    //�ɼ� �г� ����
    public void OptionPanelOfff()
    {
        OptionPanel.SetActive(false);
    }

    //���� ���� ��ư ó��
    public void GameStart()
    {
        StartGamePanel.SetActive(true);
    }

    //���ӽ����г� ����
    public void StartGamePanelOff()
    {
        StartGamePanel.SetActive(false);
    }

    //��ŷ �г� ó��
    public void Ranking()
    {
        RankingPanel.SetActive(true);
    }

    //��ŷ �г� ����
    public void RankingPanelOff()
    {
        RankingPanel.SetActive(false);
    }
}
