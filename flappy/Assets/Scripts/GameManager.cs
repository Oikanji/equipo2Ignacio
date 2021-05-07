using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool deadPlayer;
    public static GameManager pointsCounter;
    int score = 0;
    public Text pointText;
    public Text recordScore;
    public Text highscore;
    public GameObject particulasDead;
    public GameObject particulasWin;
    public GameObject particulasFireworks;
    public ParticleSystem particulasObstacle;
    public static bool win = false;

    private void Start()
    {
        pointsCounter = this;
        recordScore.text = "BEST: " + GetMaxScore().ToString();
        highscore.text = "HIGHSCORE: " + GetMaxScore().ToString();
    }

        public void RaiseScore(int s)
        {
            if (!deadPlayer)
            {
                score += s;
                pointText.text = score.ToString();
                if (score > GetMaxScore())
                {
                    recordScore.text = "BEST: " + score.ToString();
                    SaveScore(score);
                    highscore.text = "NEW HIGHSCORE!: " + score.ToString();
                    highscore.fontSize = 25;
                    win = true;
                }
            }
        }
    private void Update()
    {
        if (deadPlayer)
        {
            particulasDead.SetActive(true);

            if (win)
            {
                particulasDead.SetActive(false);
                particulasWin.SetActive(true);
                particulasFireworks.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("espacio"))
        {
            pointsCounter.RaiseScore(1);

            if (particulasObstacle.isStopped)
            {
                particulasObstacle.Play();
            }
        }
    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("Max Points", 0);
    }

    public void SaveScore(int currentPoints)
    {
        PlayerPrefs.SetInt("Max Points", currentPoints);
    }
}
