using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Option_menu : MonoBehaviour
{
    //�ɼǸ޴� ������Ʈ ��������
    public GameObject OptionBtn;
    //�������� �г� ������Ʈ ��������
    public GameObject GameExitPanel;

    //���θ޴��� �ҷ�����
    public void GameOffBtn()
    {
        GameExitPanel.SetActive(true);
    }

    //�ɼ� ��ư ������ �� (�ѱ�)
    public void OptionOn()
    {
        OptionBtn.SetActive(true);
    }

    //�ɼ� ��ư �ٽ� ������ �� (����)
    public void OptionOff()
    {
        OptionBtn.SetActive(false);
    }

    //���������г� Yes��ư
    public void GameExitYes()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    //���������г� No��ư
    public void GameExitNo()
    {
        GameExitPanel.SetActive(false);
    }
}
