/*****************************************************************************
// File Name : Health.cs
// Author : Austin Nelson
// Creation Date : March 27, 2025
//
// Brief Description : This Controls Everything to do with Health
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHP = 100;
    [SerializeField]
    private int _hp;
    [SerializeField]
    private HealthBar _healthBar;

    public int MaxHP => _maxHP;

    public int HP
    {
        get => _hp;
        private set
        {
            var isDamage = value < _hp;
            _hp = Mathf.Clamp(value, 0, _maxHP);
            if (isDamage)
            {
                Damaged?.Invoke(_hp);
            }
            else
            {
                Healed?.Invoke(_hp);
            }
            if (_hp <= 0)
            {
                Died?.Invoke();
            }
            if (_healthBar != null)
            {
                _healthBar.SetHealth(_hp);
            }
        }
    }

    public UnityEvent<int> Healed;
    public UnityEvent<int> Damaged;
    public UnityEvent Died;

    private void Awake() => _hp = _maxHP;

    public void Damage(int amount) => HP -= amount;

    public void Heal(int amount) => HP += amount;

    public void HealFull() => HP = _maxHP;

    public void Kill() => HP = 0;

    public void Adjust(int value) => HP = value;

    private void Start()
    {
        if (_healthBar != null)
        {
            _healthBar.SetMaxHealth(_maxHP);
        }
    }
}
