using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] Text comboText;
    [SerializeField] Text hitText;
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    [SerializeField] GameObject menuObject;
    [SerializeField] Button firstBotton;
    int playerHP;
    int playerMaxHp;
    int playerCombo;
    int playerScore;
    float comboStartTime;
    float comboTimer;
    bool isComboing;
    int previousMaxCombo;
    int maxCombo;
    int finalScore;
    public static bool isPause;


    void Start()
    {
        isPause = false;
        playerHP = playerMaxHp;
        playerCombo = 0;
        playerMaxHp = 6;
        comboStartTime = 2f;
        comboTimer = comboStartTime;
        isComboing = false;
        previousMaxCombo = 0;
        playerScore = 100;
    }

    private void Update()
    {
        if (Time.timeScale == 1) isPause = false;
        else isPause = true;

        ResetCombo();
        PauseMenu();
        if (PressingPause())
        {
            PauseUnPause();
        }
       // Debug.Log(isPause);
    }

    private void FixedUpdate()
    {
        UpdateMaxCombo();

        scoreText.text = playerScore.ToString("D5"); //set to 5 Digit
    }
    public bool PressingPause()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    void PauseMenu()
    {
        if(isPause)
        {
            menuObject.SetActive(true);


        }
        else menuObject.SetActive(false);
    }

    public void PauseUnPause()
    {
        if (!menuObject.activeInHierarchy) // if not pause
        {
            Time.timeScale = 0; // pause
            firstBotton.Select();
            firstBotton.OnSelect(null);
        }
        else
        {
            Time.timeScale = 1; // else resume
            PlayerAttack.normalAttack = false;
        }

    }
    
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void UpdateHP(int number)
    {
        playerHP += number;
    }
    public void AddScore(int score)
    {
        playerScore += score;
    }
    public void AddCombo(int combo) //used in Enemy Script
    {
        playerCombo += combo;
        comboTimer = comboStartTime;
        comboText.text = playerCombo.ToString();
    }

    void UpdateMaxCombo() 
    {
        if (maxCombo < previousMaxCombo)
        {
            maxCombo = previousMaxCombo;
        }
        else previousMaxCombo = playerCombo;
    }

    void ResetCombo() //if timer reach 0, reset combo
    {
        if (playerCombo > 0)
        {
            isComboing = true;
            comboTimer = Mathf.Clamp(comboTimer - Time.deltaTime, 0, comboStartTime); //use mathf.clamp to prevent timer go below 0

            if (comboTimer == 0) //reset combo and timer when combotimer = 0
            {
                isComboing = false;
                playerCombo = 0;
                comboTimer = comboStartTime;
                comboText.text = playerCombo.ToString();
            }
        }
        ShowCombo();
    }

    void ShowCombo() //only show combo text while comboing
    {
        if(isComboing)
        {
            comboText.enabled = true;
            hitText.enabled = true;
        }
        else
        {
            comboText.enabled = false;
            hitText.enabled = false;
        }
    }
}
