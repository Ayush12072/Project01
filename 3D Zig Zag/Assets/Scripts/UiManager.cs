using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance;
    public Text screenScore;
    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1;
    public Text highScore2;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        highScore1.text = "High Score : " + PlayerPrefs.GetInt("highScore");
    }
	
    public void GameStart()
    {
       
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = "Score : " + PlayerPrefs.GetInt("score");
        highScore2.text = "Best Score : " + PlayerPrefs.GetInt("highScore");
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update () {
        
    }

}
