using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {

    public int cardCount;
    //public GameObject[] availableCards;
    public List<Card> newCards = new List<Card>();

    Deck deck;

	// Use this for initialization
	void Start () {
        deck = GameObject.FindObjectOfType<Deck>();

        //Initialize();
	}
	
    void Initialize()
    {
        GenerateNewCards(deck.availableCards, cardCount);
    }

    public void GenerateNewCards(Card[] cards, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int rand = RandomWeighted();

            Card card = Instantiate(cards[rand], cards[rand].transform.position, Quaternion.identity);
            newCards.Add(card);
            card.transform.parent = transform;
        }
    }

    int RandomWeighted()
    {
        //This does not take into consideration the object's rarity when weighing the chances of selection
        //Needs to be re-written to work correctly
        int value = 0, total = 0;
        int randVal = Random.Range(0, System.Enum.GetValues(typeof(AbilityController.Ability)).Length);
        for (value = 0; value < System.Enum.GetValues(typeof(Card.Rarity)).Length; value++)
        {
            total += value;
            if (total >= randVal) break;
        }
        return value;
    }
}
