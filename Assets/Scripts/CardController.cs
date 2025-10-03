using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CardName, CardText, CardCost;
    [SerializeField] private SpriteRenderer CardArt;

    [SerializeField] private int cost;
    [SerializeField] private string name, text;
    [SerializeField] private Card card;
    
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
        CardCost.text = card.cardCost.ToString();
        cost = card.cardCost;
        CardArt.sprite = card.cardSprite;
    }
}
