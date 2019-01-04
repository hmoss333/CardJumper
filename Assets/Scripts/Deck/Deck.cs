using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> activeCards = new List<GameObject>();

	// Use this for initialization
	void Start () {
        GenerateDeck(20, cards);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateDeck(int cardCount, List<GameObject> cardList)
    {
        for (int i = 0; i < cardCount; i++)
        {
            cardList.Add(RandomCard(Random.Range(0, 5)));
        }
    }

    GameObject RandomCard(int cardNum)
    {
        GameObject tempCard = new GameObject();

        switch (cardNum)
        {
            case 0:
                tempCard.AddComponent<Card>().Initialize("Dash", AbilityController.Ability.Dash);
                break;
            case 1:
                tempCard.AddComponent<Card>().Initialize("Double Jump", AbilityController.Ability.DoubleJump);
                break;
            case 2:
                tempCard.AddComponent<Card>().Initialize("Melee", AbilityController.Ability.Melee);
                break;
            case 3:
                tempCard.AddComponent<Card>().Initialize("Gun", AbilityController.Ability.Gun);
                break;
            case 4:
                tempCard.AddComponent<Card>().Initialize("Wall Cling", AbilityController.Ability.WallJump);
                break;
            default:
                Debug.Log("Value out of range: " + cardNum);
                break;
        }

        tempCard.transform.parent = transform;
        return tempCard;
    }
}
