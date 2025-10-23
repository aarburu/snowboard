using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class CollectibleItemView : MonoBehaviour
{
    [SerializeField] private PowerUpSO powerUp;
    private SpriteRenderer se;

    private void Start()
    {
        se = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && se.enabled)
        {
            CollectibleItemSystem.Instance.ProcessItemPickup(this);
            this.DisableVisual();
        }
    }

    public PowerUpSO GetPowerUp() => powerUp;
    private void DisableVisual() => se.enabled = false;
}

