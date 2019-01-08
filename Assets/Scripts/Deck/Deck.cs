using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public Card[] availableCards;
    [HideInInspector]
    public List<Card> cards = new List<Card>();
    [HideInInspector]
    public List<Card> activeCards = new List<Card>();

	// Use this for initialization
	void Start () {
        GenerateDeck(5, availableCards, cards);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateDeck(int cardCount, Card[] cardList, List<Card> newCardList)
    {
        for (int i = 0; i < cardCount; i++)
        {
            newCardList.Add(cardList[Random.Range(0, cardList.Length)]);
        }
    }
}
