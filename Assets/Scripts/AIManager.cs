using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public GameManager gameManager;
    public CardObject highCard;
    public CardObject placingCard;
    public CardObject tableCard2;
    public CardObject tableCard3;
    public CardObject tableCard4;
    public int highValue = 0;
    public int lowValue = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.turnIndex == 1)
        {
            if(gameManager.turnCount != 0)
            {
                CheckTableCards();
                FindPlacingCard(1);
                AutoPlaceCard(placingCard, tableCard2);
            }

            if(gameManager.turnCount == 0)
            {
                PlaceRandomCard(1);
                AutoPlaceCard(placingCard, tableCard2);
            }
        }

        if(gameManager.turnIndex == 2)
        {
            if(gameManager.turnCount != 0)
            {
                CheckTableCards();
                FindPlacingCard(2);
                AutoPlaceCard(placingCard, tableCard3);
            }

            if(gameManager.turnCount == 0)
            {
                PlaceRandomCard(2);
                AutoPlaceCard(placingCard, tableCard3);
            }
        }

        if(gameManager.turnIndex == 3)
        {
            if(gameManager.turnCount != 0)
            {
                CheckTableCards();
                FindPlacingCard(3);
                AutoPlaceCard(placingCard, tableCard4);
            }

            if(gameManager.turnCount == 0)
            {
                PlaceRandomCard(3);
                AutoPlaceCard(placingCard, tableCard4);
            }
        }
        
    }

    public void AutoPlaceCard(CardObject clickedCard, CardObject tableCard)
    {
        if(clickedCard.isClickable)
        {
            if(clickedCard.cardSuit == gameManager.leadSuit || clickedCard.cardSuit == "Spade" || gameManager.leadSuit == "")
            {
                if(gameManager.trickCount < 4)
                {
                    gameManager.trickCount++;
                    gameManager.turnIndex++;
                    gameManager.turnCount++;      

                    Debug.Log("Sprite clicked!");
                    
                    if(!gameManager.isStart)
                    {
                        gameManager.SetLeadSuit(clickedCard);
                    }

                    tableCard.gameObject.SetActive(true);
                    gameObject.SetActive(false);
                    gameManager.activeCard.Add(gameObject);

                    TriggerEvent(clickedCard, tableCard);

                    if(gameManager.trickCount == 4)
                    {
                        gameManager.CheckTrick();
                    }
                }
            }

            if(ParentLackSuit(clickedCard))
            {
                if(gameManager.trickCount < 4)
                {
                    gameManager.trickCount++;
                    gameManager.turnIndex++;
                    gameManager.turnCount++;      

                    Debug.Log("Sprite clicked!");
                    
                    if(!gameManager.isStart)
                    {
                        gameManager.SetLeadSuit(clickedCard);
                    }

                    tableCard.gameObject.SetActive(true);
                    gameObject.SetActive(false);
                    gameManager.activeCard.Add(gameObject);

                    TriggerEvent(clickedCard, tableCard);

                    if(gameManager.trickCount == 4)
                    {
                        gameManager.CheckTrick();
                    }
                }
            }

            
        }
        
    }

    void TriggerEvent(CardObject clickedCard, CardObject tableCard)
    {
        Debug.Log("Triggered an event!");

        tableCard.cardImage = clickedCard.cardImage;
        tableCard.gameObject.GetComponent<SpriteRenderer>().sprite = tableCard.cardImage;
        tableCard.cardSuit = clickedCard.cardSuit;
        tableCard.cardValue = clickedCard.cardValue;
    }

    public bool ParentLackSuit(CardObject clickedCard)
    {
        if(gameManager.p1Cards.Contains(clickedCard))
        {
            if(gameManager.p1LackSuit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(gameManager.p2Cards.Contains(clickedCard))
        {
            if(gameManager.p2LackSuit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(gameManager.p3Cards.Contains(clickedCard))
        {
            if(gameManager.p3LackSuit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(gameManager.p4Cards.Contains(clickedCard))
        {
            if(gameManager.p4LackSuit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void CheckTableCards()
    {
        for(int i = 0; i<gameManager.tableCards.Count; i++)
        {
            if(gameManager.tableCards[i].gameObject.activeSelf)
            {
                if(gameManager.tableCards[i].cardSuit == "Spade" || gameManager.tableCards[i].cardSuit == gameManager.leadSuit)
                {
                    if(gameManager.tableCards[i].cardValue > highValue)
                    {
                        highValue = gameManager.tableCards[i].cardValue;
                    }
                }
            }
        }
    }

    public void FindPlacingCard(int playerIndex)
    {
        if(playerIndex == 1)
        {
            // for(int i = 0; i<gameManager.p2Cards.Count;i++)
            // {
            //     if(gameManager.p2Cards[i].gameObject.activeSelf)
            //     {
            //         if(gameManager.p2Cards[i].cardSuit == gameManager.leadSuit)
            //         {
            //             if(gameManager.p2Cards[i].cardValue > highValue)
            //             {
            //                 placingCard = gameManager.p2Cards[i];
            //             }

            //             else
            //             {
            //                 for(int j = 0; i<gameManager.p2Cards.Count; j++)
            //                 {
            //                     if(gameManager.p2Cards[j].gameObject.activeSelf)
            //                     {
            //                         if(gameManager.p2Cards[j].cardSuit == gameManager.leadSuit)
            //                         {

            //                         }
            //                     }
            //                 }
            //             }
            //         }

            //         else if(gameManager.p2Cards[i].cardSuit == "Spade")
            //         {
            //             if(gameManager.p2Cards[i].cardValue > highValue)
            //             {
            //                 placingCard = gameManager.p2Cards[i];
            //             }
            //         }
            //     }
            // }
        }
    }

    public void PlaceRandomCard(int playerIndex)
    {

    }
}
