using UnityEngine;
using System.Collections.Generic;

public class DeckController : MonoBehaviour
{
    [SerializeField] private new List<Card> playerDeck = new List<Card>();
    private new List<Card> tempDeck = new List<Card>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleDeck(List<Card> toShuffle)
    {
        tempDeck.Clear();
        while (toShuffle.Count > 0)
        {
            int randomPick = Random.Range(0, toShuffle.Count);
            tempDeck.Add(toShuffle[randomPick]);
            tempDeck.RemoveAt(randomPick);
        }
        toShuffle = tempDeck;
    }
}
