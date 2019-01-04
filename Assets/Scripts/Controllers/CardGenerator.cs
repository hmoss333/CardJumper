using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {

    public int cardCount;
    public List<GameObject> newCards = new List<GameObject>();

    Deck deck;

	// Use this for initialization
	void Start () {
        deck = GameObject.FindObjectOfType<Deck>();

        GenerateNewCards(deck.cards, cardCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateNewCards(List<GameObject> availableCards, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, availableCards.Count);

            GameObject card = Instantiate(availableCards[rand], availableCards[rand].transform.position, Quaternion.identity);
            newCards.Add(card);
            card.transform.parent = transform;
        }
    }
}
