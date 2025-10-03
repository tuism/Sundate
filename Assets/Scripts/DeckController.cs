using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DeckController : MonoBehaviour
{
    
    [SerializeField] private new List<Card> playerDeck, playerHand, playerDiscard = new List<Card>();
    [SerializeField] private new List<Card> cardPresets = new List<Card>();
    private new List<Card> tempDeck = new List<Card>();

    [SerializeField] private GameController _gameController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Card> GetPlayerDeck()
    {
        return playerDeck;
    }

    public List<Card> GetPlayerHand()
    {
        return playerHand;
    }

    public List<Card> GetPlayerDiscard()
    {
        return playerDiscard;
    }

    public void AddCard(List<Card> targetDeck, int card)
    {
        targetDeck.Add(cardPresets[card]);
    }

    public void ShuffleDeck(List<Card> targetDeck)
    {
        tempDeck.Clear();
        while (targetDeck.Count > 0)
        {
            int randomPick = Random.Range(0, targetDeck.Count);
            tempDeck.Add(targetDeck[randomPick]);
            targetDeck.RemoveAt((randomPick));
        }
        targetDeck.AddRange(tempDeck);
        tempDeck.Clear();
    }
    
    public void MoveCard(List<Card> from, List<Card> to)
    {
        to.Add(from[0]);
        from.RemoveAt(0);
    }
}
