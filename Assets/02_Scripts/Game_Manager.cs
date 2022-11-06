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
        if (Input.GetButtonDown("Cancel")) //esc 버튼으로 옵션메뉴 열수 있도록 설정
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

    public void GameSave()
    {
        //플레이어의 xy축 저장
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();
    }

    public void GameLoad()
    {
        //변수 XY에 플레이어의 좌표값 저장
        float X = PlayerPrefs.GetFloat("PlayerX");
        float Y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(X, Y, 0);
    }
}
