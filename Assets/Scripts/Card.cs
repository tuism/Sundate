using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public enum EffectType
    {
        Build,
        Land,
        Destroy,
        ChangeTime,
        ChangeCash,
        ChangeMaterial,
        ChangeElec,
        ChangeHousing,
        ChangePop,
    }

    public enum LandType
    {
        Plain,
        Green,
        Barren,
        Water
    }
    
    public enum StructureType
    {
        None,
        Any,
        Garbage,
        Tree,
        Housing,
        Water,
        Grass,
        Building
    }

    public enum TargetMode
    {
        None,
        TileMode,
    }
    public string cardName;
    public Sprite cardSprite;
    public string cardText;
    public int cardTimeCost, cardCashCost, cardElecCost, cardMatsCost;
    public StructureType targetType;
    public int targetNumberRequired;
    public EffectType cardEffect1, cardEffect2;
    public int cardEffectNumber1, cardEffectNumber2;
    public TargetMode targetMode;
}
