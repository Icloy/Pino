using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class addScore : MonoBehaviour
{
    public string addScoreURL = "http://localhost/HighScoreGame/addscore.php?";

    public static addScore instance;
    private void Awake()
    {
        instance = this;

    }

    public void SendScoreBtn()
    {
        StartCoroutine(PostScores(DataManager.instance.nowPlayer.UserName, Convert.ToInt32(Game_Score.instance.totalScore)));
    }

    IEnumerator PostScores(string name, int score)
    {
        Debug.Log("1");
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("score", score);

        WWW www = new WWW(addScoreURL, form);

        yield return www;
        Debug.Log(www.text);

    }


}