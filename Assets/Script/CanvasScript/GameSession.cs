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
    [HideInInspector] public static bool stageClear;
    [SerializeField] Text endMaxComboText;
    [SerializeField] Text endScoreText;
    [SerializeField] Text endFinalScoreText;
    [SerializeField] Text endBonusScoreText;
    [SerializeField] Button endScreenButton;
    [SerializeField] GameObject endScreenObject;
    [SerializeField] GameObject onDeadObject;
    [SerializeField] Button deadButton;
    [SerializeField] GameObject[] hpObject;
    [SerializeField] Image comboBar;
    int playerCombo;
    int playerScore;
    float comboStartTime;
    float comboTimer;
    bool isComboing;
    int previousMaxCombo;
    int maxCombo;
    int bonusScore;
    public static int finalScore;
    public static bool isPause;
    bool playerDead;

    private void Awake()
    {
        Time.timeScale = 1;
        menuObject.SetActive(false);
        onDeadObject.SetActive(false);
    }
    void Start()
    {
        playerDead = false;
        stageClear = false;
        isPause = false;
        playerCombo = 0;
        comboStartTime = 2f;
        comboTimer = comboStartTime;
        isComboing = false;
        previousMaxCombo = 0;
        playerScore = 0;
        finalScore = 0;
        bonusScore = 0;
    }

    private void Update()
    {
        if (Time.timeScale == 1) isPause = false;
        else isPause = true;
        UpdateHP();
        ResetCombo();
        PauseMenu();
        if (PressingPause())
        {
            PauseUnPause();
        }
        if(playerDead)
        {
            onDeadObject.SetActive(true);
            deadButton.Select();
            deadButton.OnSelect(null);
        }
      //  Debug.Log(stageClear);
    }

    private void FixedUpdate()
    {
        UpdateMaxCombo();
        scoreText.text = playerScore.ToString("D5"); //set to 5 Digit
        dump();
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
            Time.timeScale = 0f; // pause
            firstBotton.Select();
            firstBotton.OnSelect(null);
        }
        else
        {
            Time.timeScale = 1f; // else resume
        }

    }
    
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void UpdateHP()
    {
        if (PlayerInfo.playerHP == 6)
        {
            for(int i = 0; i < 6; i++)
            {
                hpObject[i].SetActive(true);
            }
        }
        else if (PlayerInfo.playerHP == 5)
        {
            for (int i = 0; i < 5; i++)
            {
                hpObject[i].SetActive(true);
            }
            hpObject[5].SetActive(false);
        }
        else if (PlayerInfo.playerHP == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                hpObject[i].SetActive(true);
            }
            for(int i = 5; i > 3; i--)
            {
                hpObject[i].SetActive(false);
            }
        }
        else if (PlayerInfo.playerHP == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                hpObject[i].SetActive(true);
            }
            for (int i = 5; i > 2; i--)
            {
                hpObject[i].SetActive(false);
            }
        }
        else if (PlayerInfo.playerHP == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                hpObject[i].SetActive(true);
            }
            for (int i = 5; i > 1; i--)
            {
                hpObject[i].SetActive(false);
            }
        }
        else if (PlayerInfo.playerHP == 1)
        {
            for (int i = 0; i < 1; i++)
            {
                hpObject[i].SetActive(true);
            }
            for (int i = 5; i > 0; i--)
            {
                hpObject[i].SetActive(false);
            }
        }
        else if (PlayerInfo.playerHP <= 0)
        {
            for (int i = 5; i >= 0; i--)
            {
                hpObject[i].SetActive(false);
            }
            playerDead = true;
        }
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
            comboBar.enabled = true;
            comboBar.fillAmount = (comboTimer / comboStartTime);
        }
        else
        {
            comboText.enabled = false;
            hitText.enabled = false;
            comboBar.enabled = false;
        }
    }

    void dump()
    {
        bonusScore = maxCombo * 100;
        finalScore = playerScore + bonusScore;
        endMaxComboText.text = maxCombo.ToString();
        endScoreText.text = playerScore.ToString();
        endBonusScoreText.text = bonusScore.ToString();
        endFinalScoreText.text = finalScore.ToString();


        if (stageClear)
        {
            endScreenObject.SetActive(true);
            Time.timeScale = 0;
            endScreenButton.Select();
            endScreenButton.OnSelect(null);
        }
    }
}
