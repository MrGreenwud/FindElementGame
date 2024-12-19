using System;
using UnityEngine;

[Serializable]
public class CardData
{
    [SerializeField] private Sprite _sprite;
    
    public Sprite Sprite => _sprite;
}