using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingMessage : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    private TMP_Text _damageValue;

    public float LifeTime = 0.8f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _damageValue = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    private void SetMessage(string msg)
    {
        _damageValue.SetText(msg);
    }
}
