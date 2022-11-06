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
    //������ �����Ǿ����� Ȯ���ϴ� ������ Ÿ�Ժ��� ����
    bool isPause = false;

    //���θ޴��� �ҷ�����
    public void GameOffBtn()
    {
        GameExitPanel.SetActive(true);
    }

    //�ɼ� ��ư ������ �� (�ѱ�)
    public void OptionOn()
    {
        OptionBtn.SetActive(true);
        PauseGame();
    }

    //�ɼ� ��ư �ٽ� ������ �� (����)
    public void OptionOff()
    {
        OptionBtn.SetActive(false);
        PauseGame();
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
