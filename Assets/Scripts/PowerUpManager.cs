using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUpSO PowerUp;
    private float InitialValue;
    private SpriteRenderer se;

    private void Start()
    {
        se = GetComponent<SpriteRenderer>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && se.enabled)
        {
            var PlayerController = FindObjectsByType<PlayerController>(FindObjectsSortMode.None).First();
            PlayerController.ActivatePowerUp(PowerUp);

            se.enabled = false;

            StartCoroutine(PlayerController.DectivatePowerUp(PowerUp));
        }
    }

}

