using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject scoreBoardObject;
    public static bool isCheckScore;

    // Start is called before the first frame update
    private void Awake()
    {
        if(scoreBoardObject.activeInHierarchy) scoreBoardObject.SetActive(false);
    }
    void Start()
    {
        isCheckScore = false;
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void CheckScore()
    {
        if (!scoreBoardObject.activeInHierarchy)
        {
            isCheckScore = true;
            scoreBoardObject.SetActive(true);
        }
        else
        {
            isCheckScore = false;
            scoreBoardObject.SetActive(false);
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
