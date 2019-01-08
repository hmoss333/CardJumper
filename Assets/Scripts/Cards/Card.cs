using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public Texture texture;
    public string cardName;
    public AbilityController.Ability cardAbility;
    public enum Rarity { Common, Uncommon, Rare };
    public Rarity cardRarity;

    public bool selected;

    Deck deck;

    // Use this for initialization
    void Start()
    {
        deck = GameObject.FindObjectOfType<Deck>();
    }

    public void Initialize(string name, AbilityController.Ability ability, Rarity rarity)
    {
        cardName = name;
        cardAbility = ability;
        cardRarity = rarity;

        gameObject.name = cardName;
        GetComponentInChildren<Text>().text = cardName;
        texture = Resources.Load(cardName + ".png") as Texture;        
    }

    public void SelectCard()
    {
        if (!selected)
        {
            if (deck.activeCards.Count < 3)
                Select();
            else
                selected = false;
        }
        else if (selected)
        {
            Deselect();
        }
    }

    private void Select()
    {
        selected = true;
        deck.activeCards.Add(this);
        deck.cards.Remove(this);
        AbilityController.ActivateAbility(cardAbility);
        GetComponent<Image>().color = Color.yellow;
    }

    private void Deselect()
    {
        selected = false;
        deck.cards.Add(this);
        deck.activeCards.Remove(this);
        AbilityController.DeactivateAbility(cardAbility);
        GetComponent<Image>().color = Color.white;
    }
}
