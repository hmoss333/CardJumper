using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int currentLevel = 0;
    public GameObject[] levels;
    public GameObject cardSelectUI;
    public Vector3 LeftMax;
    public Vector3 RightMax;

    bool cardsSelected;
    public static bool isPlaying;

    Deck deck;
    //CardGenerator cg;

    //Gameplay Loop::
    //Generate Level
    //Display cards to select
    //Lock in selection (up to 3 cards per level)
    //Start level
    ////Complete level:
    //////Award new cards
    //////Restart Loop
    ////Fail Level:
    //////Re-initialize level (may be able to simplify this by just having each level as a prefab that can be destroyed/instantiated as needed)


    // Use this for initialization
    void Start () {
        deck = GameObject.FindObjectOfType<Deck>();
        isPlaying = false;

        //InitializeLevel(levels[currentLevel]);
        StartCoroutine(DisplayCards(deck.cards));
        //StartGameplay();
	}

    void InitializeLevel (GameObject levelPrefab)
    {

    }

    void UnloadLevel(GameObject levelPrefab)
    {

    }

    IEnumerator DisplayCards(List<Card> cards)
    {
        yield return new WaitForSeconds(1);
        float distance = 1.0f / cards.Count;
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 cardPos = LeftMax + (RightMax - LeftMax) * (distance * i);
            Card card = Instantiate(cards[i], cardSelectUI.transform);
            card.transform.localPosition = cardPos;
        }

        cardSelectUI.SetActive(true);
        while (!cardsSelected)
            yield return null;
        cardSelectUI.SetActive(false);

        StartGameplay();
    }

    void StartGameplay()
    {
        Debug.Log("Start Gameplay");
        isPlaying = true;
    }

    void GameState(int step)
    {
        
    }

    public void ConfirmCards()
    {
        //Button function to start the level
        cardsSelected = true;
    }
}
