using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Deck deck;
    public List<CardObject> p1Cards;
    public List<CardObject> p2Cards;
    public List<CardObject> p3Cards;
    public List<CardObject> p4Cards;
    public List<CardObject> tableCards;
    private List<Sprite> dealtCards = new List<Sprite>();
    public bool isStart = false;
    public string leadSuit = "";
    public int highCard = 0;
    public int highIndex = 0;
    public List<TextMeshProUGUI> scoreText;
    public List<int> score;
    public int trickCount = 0;
    public List<GameObject> activeCard;
    public BidManager bidManager;
    public bool hasSpade;
    public int roundCompleted = 0;
    public int trickCompleted = 0;
    public ScoreManager scoreManager;
    public int winnerIndex = 0;
    public int turnIndex = 0;
    public int turnCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        DealDeck();
        bidManager.p1bid.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckScore();

        if(turnIndex>3)
        {
            turnIndex = 0;
        }
        
        if(turnCount == 4)
        {
            turnIndex = winnerIndex;
            turnCount = 0;
        }

        SetTurn(turnIndex);
    }

    public void DealDeck()
    {
        while(!hasSpade)
        {
            DistributeCards();

            bool p1HasSpade = false;
            bool p2HasSpade = false;
            bool p3HasSpade = false;
            bool p4HasSpade = false;

            for(int i = 0;i<13; i++)
            {
                if(p1Cards[i].cardSuit == "Spade")
                {
                    p1HasSpade = true;
                }
            }

            for(int i = 0;i<13; i++)
            {
                if(p2Cards[i].cardSuit == "Spade")
                {
                    p2HasSpade = true;
                }
            }

            for(int i = 0;i<13; i++)
            {
                if(p3Cards[i].cardSuit == "Spade")
                {
                    p3HasSpade = true;
                }
            }

            for(int i = 0;i<13; i++)
            {
                if(p4Cards[i].cardSuit == "Spade")
                {
                    p4HasSpade = true;
                }
            }

            if(p1HasSpade && p2HasSpade && p3HasSpade && p4HasSpade)
            {
                hasSpade = true;
            }
        }    
    }

    public void DealCards(List<CardObject> player)
    {
        int i = 0;
        while(i < 13)
        {
            int randomValue = Random.Range(0, 52);

            if(!dealtCards.Contains(deck.card[randomValue].cardImage))
            {
                player[i].cardImage = deck.card[randomValue].cardImage;
                player[i].gameObject.GetComponent<SpriteRenderer>().sprite = player[i].cardImage;
                player[i].cardSuit = deck.card[randomValue].cardSuit;
                player[i].cardValue = deck.card[randomValue].cardValue;
                dealtCards.Add(deck.card[randomValue].cardImage);
                i++;
            }
        }
    }

    public void DistributeCards()
    {
        DealCards(p1Cards);
        DealCards(p2Cards);
        DealCards(p3Cards);
        DealCards(p4Cards);
    }

    public void SetLeadSuit(CardObject clickedCard)
    {
        leadSuit = clickedCard.cardSuit;
        Debug.Log(leadSuit);
        isStart = true;  
    }


    public void CheckTrick()
    {
        for(int i = 0; i < 4; i++)
        {
            if(tableCards[i].cardSuit == "Spade" && tableCards[i].cardValue >highCard)
            {
                highCard = tableCards[i].cardValue;
                highIndex = i;
                winnerIndex = i;
            }
        }

        for(int i = 0; i < 4; i++)
        {
            if(tableCards[i].cardSuit == leadSuit && tableCards[i].cardValue >highCard)
            {
                highCard = tableCards[i].cardValue;
                highIndex = i;
                winnerIndex = i;
            }
        }

        score[highIndex]++;
    
    }

    public void CheckScore()
    {
        for(int i = 0; i<scoreText.Count; i++)
        {
            scoreText[i].text = score[i].ToString() + "/" + bidManager.bid[i].ToString();
        }
    }

    public void ResetTrick()
    {
        trickCompleted++;

        if(trickCompleted == 13)
        {
            ShowScore();
        }

        if(trickCompleted <= 13)
        {
            foreach(CardObject card in tableCards)
            {
                card.gameObject.SetActive(false);
            }

            isStart = false;
            leadSuit = "";
            highCard = 0;
            highIndex = 0;
            trickCount = 0;
            
            //trickCompleted++;
        }
    }

    public void ResetRound()
    {
        roundCompleted++;

        if(roundCompleted == 5)
        {
            Debug.Log("game over");
            scoreManager.scoreboard.SetActive(true);
            scoreManager.CalculateTotal();
            
        }
        
        if(roundCompleted < 5)
        {
            //roundCompleted++;

            foreach(CardObject card in tableCards)
            {
                card.gameObject.SetActive(false);
            }

            isStart = false;
            leadSuit = "";
            highCard = 0;
            highIndex = 0;
            trickCount = 0;
            trickCompleted = 0;
            
            foreach(GameObject card in activeCard)
            {
                card.SetActive(true);
            }
            
            activeCard.Clear();
            dealtCards.Clear();

            for(int i = 0; i < score.Count; i++)
            {
                score[i] = 0;
            }

            bidManager.ResetBid();

            hasSpade = false;

            DealDeck();

            bidManager.p1bid.SetActive(true);
        }
    }

    public void ShowScore()
    {
        scoreManager.scoreboard.SetActive(true);
        
        if(roundCompleted == 0)
        {
            scoreManager.CalculateScore(scoreManager.round1Score);
        }

        if(roundCompleted == 1)
        {
            scoreManager.CalculateScore(scoreManager.round2Score);
        }

        if(roundCompleted == 2)
        {
            scoreManager.CalculateScore(scoreManager.round3Score);
        }

        if(roundCompleted == 3)
        {
            scoreManager.CalculateScore(scoreManager.round4Score);
        }

        if(roundCompleted == 4)
        {
            scoreManager.CalculateScore(scoreManager.round5Score);
        }
    }

    public void ShowScoreboard()
    {
        scoreManager.scoreboard.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }


    public void SetTurn(int currentTurn)
    {
        if(currentTurn == 0)
        {
            for(int i = 0; i<p1Cards.Count;i++)
            {
                p1Cards[i].isClickable = true;
            }

            for(int i = 0; i<p1Cards.Count;i++)
            {
                p2Cards[i].isClickable = false;
                p3Cards[i].isClickable = false;
                p4Cards[i].isClickable = false;
            }
        }

        if(currentTurn == 1)
        {
            for(int i = 0; i<p2Cards.Count;i++)
            {
                p2Cards[i].isClickable = true;
            }

            for(int i = 0; i<p2Cards.Count;i++)
            {
                p1Cards[i].isClickable = false;
                p3Cards[i].isClickable = false;
                p4Cards[i].isClickable = false;
            }
        }

        if(currentTurn == 2)
        {
            for(int i = 0; i<p3Cards.Count;i++)
            {
                p3Cards[i].isClickable = true;
            }

            for(int i = 0; i<p3Cards.Count;i++)
            {
                p2Cards[i].isClickable = false;
                p1Cards[i].isClickable = false;
                p4Cards[i].isClickable = false;
            }
        }

        if(currentTurn == 3)
        {
            for(int i = 0; i<p4Cards.Count;i++)
            {
                p4Cards[i].isClickable = true;
            }

            for(int i = 0; i<p4Cards.Count;i++)
            {
                p2Cards[i].isClickable = false;
                p3Cards[i].isClickable = false;
                p1Cards[i].isClickable = false;
            }
        }
    }


}
