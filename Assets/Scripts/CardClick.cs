using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClick : MonoBehaviour
{
    private CardObject clickedCard;
    public CardObject tableCard;
    public GameManager gameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        clickedCard = GetComponent<CardObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(gameManager.trickCount < 4)
        {
            gameManager.trickCount++;

            Debug.Log("Sprite clicked!");
            
            if(!gameManager.isStart)
            {
                gameManager.SetLeadSuit(clickedCard);
            }

            tableCard.gameObject.SetActive(true);
            gameObject.SetActive(false);
            gameManager.activeCard.Add(gameObject);

            TriggerEvent();

            if(gameManager.trickCount == 4)
            {
                gameManager.CheckTrick();
            }
        }
        
    }

    void TriggerEvent()
    {
        Debug.Log("Triggered an event!");

        tableCard.cardImage = clickedCard.cardImage;
        tableCard.gameObject.GetComponent<SpriteRenderer>().sprite = tableCard.cardImage;
        tableCard.cardSuit = clickedCard.cardSuit;
        tableCard.cardValue = clickedCard.cardValue;
    }

}
