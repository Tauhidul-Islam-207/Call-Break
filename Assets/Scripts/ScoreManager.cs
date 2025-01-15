using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<TextMeshProUGUI> round1Score;
    public List<TextMeshProUGUI> round2Score;
    public List<TextMeshProUGUI> round3Score;
    public List<TextMeshProUGUI> round4Score;
    public List<TextMeshProUGUI> round5Score;
    public List<TextMeshProUGUI> totalScore;
    public List<float> total;
    public GameManager gameManager;
    public BidManager bidManager;
    public GameObject scoreboard;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateScore(List<TextMeshProUGUI> round)
    {
        for(int i = 0; i<round.Count;i++)
        {
            if(gameManager.score[i] > bidManager.bid[i])
            {
                round[i].text = bidManager.bid[i].ToString() + "." + (gameManager.score[i]-bidManager.bid[i]).ToString();
            }

            if(gameManager.score[i] < bidManager.bid[i])
            {
                round[i].text = "-" + bidManager.bid[i].ToString();
            }

            if(gameManager.score[i] == bidManager.bid[i])
            {
                round[i].text = bidManager.bid[i].ToString();
            }
        }
    }

    public void CalculateTotal()
    {
        for(int i = 0; i<total.Count;i++)
        {
            float r1 = float.Parse(round1Score[i].text);
            float r2 = float.Parse(round2Score[i].text);
            float r3 = float.Parse(round3Score[i].text);
            float r4 = float.Parse(round4Score[i].text);
            float r5 = float.Parse(round5Score[i].text);
            total[i] = r1 + r2 + r3 + r4 + r5;
            totalScore[i].text = total[i].ToString();
        }
    }


    public void CloseScore()
    {
        scoreboard.SetActive(false);
    }
}
