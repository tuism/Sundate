using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DeckController : MonoBehaviour
{
    [SerializeField] private new List<Card> playerDeck = new List<Card>();
    [SerializeField] private new List<Card> cardPresets = new List<Card>();
    private new List<Card> tempDeck = new List<Card>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDeck.Add(cardPresets[0]);
        playerDeck.Add(cardPresets[0]);
        playerDeck.Add(cardPresets[0]);
        playerDeck.Add(cardPresets[0]);
        playerDeck.Add(cardPresets[1]);
        playerDeck.Add(cardPresets[2]);
        playerDeck.Add(cardPresets[3]);
        playerDeck.Add(cardPresets[3]);
        ShuffleDeck(playerDeck);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleDeck(List<Card> toShuffle)
    {
        tempDeck.Clear();
        Debug.Log(toShuffle.Count);
        while (toShuffle.Count > 0)
        {
            int randomPick = Random.Range(0, toShuffle.Count);
            Debug.Log(randomPick);
            tempDeck.Add(toShuffle[randomPick]);
            toShuffle.RemoveAt((randomPick));
        }
        toShuffle.AddRange(tempDeck);
        tempDeck.Clear();
    }
}
