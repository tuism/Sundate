using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public enum EffectType
    {
        Shoot,
        Move,
        Recover
    }
    public string cardName;
    public int cardCost;
    public Sprite cardSprite;
    public string cardText;
    public EffectType cardType;
}
