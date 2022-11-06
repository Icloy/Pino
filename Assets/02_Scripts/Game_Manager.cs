using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject optionMenu;
    bool isPause = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) //esc ��ư���� �ɼǸ޴� ���� �ֵ��� ����
        {
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

      
    public void PauseGame() //������ ���� ���θ� ����
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

    public void GameSave()
    {
        //�÷��̾��� xy�� ����
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();
    }

    public void GameLoad()
    {
        //���� XY�� �÷��̾��� ��ǥ�� ����
        float X = PlayerPrefs.GetFloat("PlayerX");
        float Y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(X, Y, 0);
    }
}
