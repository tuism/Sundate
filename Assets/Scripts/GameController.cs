using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Serialization;

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
    [SerializeField] private int selectedHandCardIndex;
    [SerializeField] private Vector3 mousePos;
    // private bool targetTileMode, targetCursorMode;
    private Card.TargetMode targetMode;
    private CardController selectedCard;
    private bool clickedMap;
    
    [Header("prefabs")]
    [SerializeField] private GameObject CardUi;
    
    [Header("prepopulated")] 
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject playCardCursor, targetLineCursor, targetLine, crosshairCursor, playerObj;
    [SerializeField] private List<GameObject> targetLineRange = new List<GameObject>();
    [SerializeField] private GridController _gridController;
    [SerializeField] private DeckController _deckController;
    [SerializeField] private InputController _inputController;
    private Vector3 offstage = new Vector3(-100, -100, 0);
    
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
        AnnounceCursorExit();
        playCardCursor.transform.position = offstage;
        targetMode = Card.TargetMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.a_selectCard:
                if (selectedHandCardIndex != 0)
                {
                    //doStuff
                    selectedCard = CardControllersInHand[selectedHandCardIndex - 1];
                    targetMode = selectedCard.GetCard().targetMode;
                    switch (targetMode)
                    {
                        case Card.TargetMode.CursorMode:
                            for (int i = 0; i < targetLineRange.Count; i++)
                            {
                                if (selectedCard.GetPower() > i+1)
                                {
                                    targetLineRange[i].SetActive(true);
                                }
                                else
                                {
                                    targetLineRange[i].SetActive(false);
                                }
                            }
                            break;
                    }
                    playCardCursor.transform.position = selectedCard.GameObject().transform.position;
                    gameState = GameState.b_selectTarget;
                    selectedHandCardIndex = 0;
                }
                break;
            case GameState.b_selectTarget:
                switch (targetMode)
                {
                    case Card.TargetMode.CursorMode:
                        targetLine.transform.LookAt(mousePos);
                        crosshairCursor.transform.position = mousePos;
                        break;
                }

                if (clickedMap)
                {
                    switch (selectedCard.GetType())
                    {
                        case Card.EffectType.Shoot:
                            break;
                        case Card.EffectType.Move:
                            break;
                        case Card.EffectType.Recover:
                            break;
                        case Card.EffectType.Block:
                            break;
                    }
                }
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
        if (targetMode == Card.TargetMode.TileMode) SetCursor(targetPos);
        if (targetMode == Card.TargetMode.CursorMode)
        {
            targetLineCursor.transform.position = playerObj.transform.position;
            crosshairCursor.transform.position = mousePos;
        }
    }

    public void AnnounceCursorExit()
    {
        SetCursor(offstage);
        targetLineCursor.transform.position = offstage;
        crosshairCursor.transform.position = offstage;
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
                selectedHandCardIndex = input;
                break;
            case GameState.b_selectTarget:
                //cancel card selection
                CardControllersInHand[input-1].rolloffEffect();
                Debug.Log("announce");
                playCardCursor.transform.position = new Vector3(-100, -100, 0);
                selectedHandCardIndex = 0;
                targetMode = Card.TargetMode.None;
                gameState = GameState.a_selectCard;
            break;
        }
    }

    public void AnnounceMousePos(Vector3 input)
    {
        mousePos = input;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void AnnounceMouseClick()
    {
        
    }
}
