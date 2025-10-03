using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [Header("vars")]
    [SerializeField] private List<CardController> CardControllersInHand = new List<CardController>();
    [SerializeField] private List<GameObject> CardsInHandUI = new List<GameObject>();
    
    [Header("prefabs")]
    [SerializeField] private GameObject CardUi;
    
    [Header("prepopulated")] 
    [SerializeField] private GameObject cursor;
    [SerializeField] private GridController _gridController;
    [SerializeField] private DeckController _deckController;
    [SerializeField] private InputController _inputController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _deckController.AddCard(_deckController.GetPlayerDeck(), 0);
        _deckController.AddCard(_deckController.GetPlayerDeck(), 0);
        _deckController.AddCard(_deckController.GetPlayerDeck(), 0);
        _deckController.AddCard(_deckController.GetPlayerDeck(), 1);
        _deckController.AddCard(_deckController.GetPlayerDeck(), 1);
        _deckController.AddCard(_deckController.GetPlayerDeck(), 2);
        _deckController.AddCard(_deckController.GetPlayerDeck(), 2);
        _deckController.AddCard(_deckController.GetPlayerDeck(), 3);
        _deckController.ShuffleDeck(_deckController.GetPlayerDeck());
        DrawCard();
        DrawCard();
        DrawCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void UpdateHand()
    {
        
    }

    private void AddToHandUI(Card inCard)
    {
        GameObject newCardUI = Instantiate(CardUi,
            new Vector3((_deckController.GetPlayerHand().Count * 2.1f)-1, 0f, -2.3f), Quaternion.identity);
        CardController tempCardController = newCardUI.GetComponent<CardController>();
        tempCardController.SetArt(inCard);
    }

    public void DrawCard()
    {
        _deckController.MoveCard(_deckController.GetPlayerDeck(), _deckController.GetPlayerHand());
        AddToHandUI(_deckController.GetPlayerHand()[_deckController.GetPlayerHand().Count-1]);
    }

    public void AnnounceCursorEnter(Vector2 targetPos)
    {
        SetCursor(targetPos);
    }

    public void AnnounceCursorExit()
    {
        SetCursor(new Vector2(-100,-100));
    }

    private void SetCursor(Vector2 targetPos)
    {
        cursor.transform.position = new Vector3(targetPos.x, 0.02f, targetPos.y);
    }
}
