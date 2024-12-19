

using UnityEngine;

public class LevelData : ScriptableObject
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private CardBundleData[] _cardBundleData;
}