using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Deck deck;
    public List<SpriteRenderer> p1Cards;
    public List<SpriteRenderer> p2Cards;
    public List<SpriteRenderer> p3Cards;
    public List<SpriteRenderer> p4Cards;
    private List<Sprite> dealtCards = new List<Sprite>();


    // Start is called before the first frame update
    void Start()
    {
        DealDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDeck()
    {
        DealCards(p1Cards);
        DealCards(p2Cards);
        DealCards(p3Cards);
        DealCards(p4Cards);
    }

    public void DealCards(List<SpriteRenderer> player)
    {
        int i = 0;
        while(i < 13)
        {
            int randomValue = Random.Range(0, 52);

            if(!dealtCards.Contains(deck.card[randomValue]))
            {
                player[i].sprite = deck.card[randomValue];
                dealtCards.Add(deck.card[randomValue]);
                i++;
            }
        }
    }
}
