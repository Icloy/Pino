using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private string secretKey = "mySecretKey";
    public string highscoreURL = "http://localhost/HighScoreGame/display.php";
    public Text nameResultText;
    public Text scoreResultText;


    public void GetScoreBtn()
    {
        nameResultText.text = "\n ";
        scoreResultText.text = "\n ";
        StartCoroutine(GetScores());
    }

    IEnumerator GetScores()
    {
        UnityWebRequest hs_get = UnityWebRequest.Get(highscoreURL);
        yield return hs_get.SendWebRequest();
        if (hs_get.error != null)
            Debug.Log("There was an error getting the high score: "
                    + hs_get.error);
        else
        {
            string dataText = hs_get.downloadHandler.text;
            MatchCollection mc = Regex.Matches(dataText, @"_");
            if (mc.Count > 0)
            {
                string[] splitData = Regex.Split(dataText, @"_");
                for (int i = 0; i < mc.Count; i++)
                {
                    if (i % 2 == 0)
                        nameResultText.text +=
                                            splitData[i];
                    else
                        scoreResultText.text +=
                                            splitData[i];
                }
            }
        }
    }
}