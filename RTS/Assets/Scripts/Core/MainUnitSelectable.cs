using Abstractions;
using UnityEngine;

public class MainUnitSelectable : MonoBehaviour, ISelectable
{
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    private float _health = 1000;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
}

