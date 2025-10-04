using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        a_selectCard,
        b_selectTarget,
        c_executing,
        d_cleanUp
    }
    [Header("vars")]
    [SerializeField] private List<CardController> CardControllersInHand = new List<CardController>();
    [SerializeField] private List<GameObject> CardsInHandUI = new List<GameObject>();
    [SerializeField] private GameState gameState;
    [SerializeField] private int selectedHandCard;
    private bool targetTileMode;
    
    [Header("prefabs")]
    [SerializeField] private GameObject CardUi;
    
    [Header("prepopulated")] 
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject playCardCursor;
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
        DrawCard();
        gameState = GameState.a_selectCard;
        playCardCursor.transform.position = new Vector3(-100, -100, 0);
        targetTileMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.a_selectCard:
                if (selectedHandCard != 0)
                {
                    Debug.Log("update");
                    //doStuff
                    targetTileMode = CardControllersInHand[selectedHandCard-1].GetCard().targetTileMode;
                    playCardCursor.transform.position = CardControllersInHand[selectedHandCard-1].transform.position;
                    gameState = GameState.b_selectTarget;
                    selectedHandCard = 0;
                }
                break;
            case GameState.b_selectTarget:
                break;
        }
    }
    
    private void UpdateHand()
    {
        
    }

    private void AlignHandUi()
    {
        for (int i = 0; i < CardControllersInHand.Count; i++)
        {
            CardControllersInHand[i].transform.position = new Vector3(i * 2.1f + (_gridController.GetGridSize().x/2) - (CardControllersInHand.Count) + 0.3f, 0f, -2.8f);
        }
    }

    private void AddToHandUI(Card inCard)
    {
        GameObject newCardUI = Instantiate(CardUi,
            new Vector3((_deckController.GetPlayerHand().Count * 2.1f)-1, 0f, -2.3f), Quaternion.identity);
        CardController tempCardController = newCardUI.GetComponent<CardController>();
        tempCardController.SetArt(inCard);
        CardControllersInHand.Add(tempCardController);
        tempCardController.SetHandIndex(CardControllersInHand.Count);
        tempCardController.SetGameController(this);
        AlignHandUi();
    }

    public void DrawCard()
    {
        _deckController.MoveCard(_deckController.GetPlayerDeck(), _deckController.GetPlayerHand());
        AddToHandUI(_deckController.GetPlayerHand()[_deckController.GetPlayerHand().Count-1]);
    }

    public void AnnounceCursorEnter(Vector2 targetPos)
    {
        if (targetTileMode) SetCursor(targetPos);
    }

    public void AnnounceCursorExit()
    {
        SetCursor(new Vector2(-100,-100));
    }

    private void SetCursor(Vector2 targetPos)
    {
        cursor.transform.position = new Vector3(targetPos.x, 0.02f, targetPos.y);
    }

    public void AnnounceHandSelected(int input)
    {
        Debug.Log(input);
    }

    public void AnnounceHandClicked(int input)
    {
        switch (gameState)
        {
            case GameState.a_selectCard:
                selectedHandCard = input;
                break;
            case GameState.b_selectTarget:
                //cancel card selection
                CardControllersInHand[input-1].rolloffEffect();
                Debug.Log("announce");
                playCardCursor.transform.position = new Vector3(-100, -100, 0);
                selectedHandCard = 0;
                targetTileMode = false;
                gameState = GameState.a_selectCard;
            break;
        }
    }

    public GameState GetGameState()
    {
        return gameState;
    }
}
