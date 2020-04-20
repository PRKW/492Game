using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour
{
    [SerializeField] Text[] highScoreText;
    [SerializeField] string highScoreChoice;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        //after stage clear , if selected scene finalscore > highscore it become new high score
        if(GameSession.stageClear == true)
        {
            if (highScoreChoice == "1" && (GameSession.finalScore > PlayerPrefs.GetInt("HighScore1",0)) ) PlayerPrefs.SetInt("HighScore1", GameSession.finalScore);
            if (highScoreChoice == "2" && (GameSession.finalScore > PlayerPrefs.GetInt("HighScore2", 0))) PlayerPrefs.SetInt("HighScore2", GameSession.finalScore);
            if (highScoreChoice == "3" && (GameSession.finalScore > PlayerPrefs.GetInt("HighScore3", 0))) PlayerPrefs.SetInt("HighScore3", GameSession.finalScore);
            PlayerPrefs.Save();
        }
        if(MainMenu.isCheckScore)
        {
            highScoreText[0].text = PlayerPrefs.GetInt("HighScore1", 0).ToString();
            highScoreText[1].text = PlayerPrefs.GetInt("HighScore2", 0).ToString();
            highScoreText[2].text = PlayerPrefs.GetInt("HighScore3", 0).ToString();
        }    //"Get" value in choosen variable when scoreboard is active
    }

}
