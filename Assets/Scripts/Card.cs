using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public enum EffectType
    {
        Build,
        Land,
        Effect,
        Destroy,
        Change,
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
        CursorMode
    }
    public string cardName;
    public int cardCost, power;
    public Sprite cardSprite;
    public string cardText;
    public EffectType cardEffect;
    // public bool targetTileMode;
    // public bool targetCursorMode;
    public TargetMode targetMode;
}
