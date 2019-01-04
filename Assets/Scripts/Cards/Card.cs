using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public Texture texture;
    public string cardName;
    public AbilityController.Ability cardAbility;

    bool active;
    public bool selected;

    Deck deck;
    CardGenerator cardGen;

    // Use this for initialization
    void Start()
    {
        deck = GameObject.FindObjectOfType<Deck>();
        cardGen = GameObject.FindObjectOfType<CardGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected && !active)
        {
            if (deck.activeCards.Count < 3)
                Select();
            else
                selected = false;
        }
        else if (!selected && active)
        {
            Deselect();
        }
    }

    public void Initialize(string name, AbilityController.Ability ability)
    {
        cardName = name;
        cardAbility = ability;

        gameObject.name = cardName;
        texture = Resources.Load(cardName + ".png") as Texture;
    }

    public void Select()
    {
        active = true;
        deck.activeCards.Add(this.gameObject);
        deck.cards.Remove(this.gameObject);
        AbilityController.ActivateAbility(cardAbility);
    }

    public void Deselect()
    {
        active = false;
        deck.cards.Add(this.gameObject);
        deck.activeCards.Remove(this.gameObject);
        AbilityController.DeactivateAbility(cardAbility);
    }
}
