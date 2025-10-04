using System;
using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CardName, CardText, CardCost;
    [SerializeField] private SpriteRenderer CardArt;
    [SerializeField] private Transform container;

    [SerializeField] private int cost, handIndex;
    [SerializeField] private string name, text;
    [SerializeField] private Card card;
    [SerializeField] private Collider _collider;
    [SerializeField] private GameController _gameController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetArt(Card inCard)
    {
        card = inCard;
        CardName.text = card.cardName;
        name = card.cardName;
        CardText.text = card.cardText;
        text = card.cardText;
        CardCost.text = card.cardTimeCost.ToString();
        cost = card.cardTimeCost;
        CardArt.sprite = card.cardSprite;
    }

    private void OnMouseEnter()
    {
        if (_gameController.GetGameState() == GameController.GameState.a_selectCard)
        {
            rolloverEffect();
            // _gameController.AnnounceHandSelected(handIndex);
        }
    }
    
    private void OnMouseExit()
    {
        if (_gameController.GetGameState() == GameController.GameState.a_selectCard)
        {
            rolloffEffect();
        }
    }

    public void rolloverEffect()
    {
        container.transform.localPosition = new Vector3(0, 0, 0.3f);
    }

    public void rolloffEffect()
    {
        container.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void OnMouseDown()
    {
        _gameController.AnnounceHandClicked(handIndex);
    }

    public void SetHandIndex(int input)
    {
        handIndex = input;
    }

    public int GetHandIndex()
    {
        return handIndex;
    }

    public void SetGameController(GameController input)
    {
        _gameController = input;
    }

    public Card GetCard()
    {
        return card;
    }
}
