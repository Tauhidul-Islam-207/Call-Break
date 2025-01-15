using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Card", menuName = "Game/Card")]
public class Card : ScriptableObject
{

    public string cardSuit;
    public int cardValue;
    public Sprite cardImage;

}
