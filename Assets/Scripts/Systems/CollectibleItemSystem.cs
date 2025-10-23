using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CollectibleItemSystem : Singleton<CollectibleItemSystem>
{
    [field: SerializeField] public PlayerController player { get; set; }
    private List<PowerUpSO> _PickedUpPowerUps;

    public List<PowerUpSO> PickedUpPowerUps { get; private set; } = new();
    

    public void ProcessItemPickup(CollectibleItemView item)
    {
        StoreItem(item.GetPowerUp());
        ActivatePowerUp(item.GetPowerUp().GetPowerUpType);
    }

    public void StoreItem(PowerUpSO powerUp)
    {
        PickedUpPowerUps.Add(powerUp);
    }

    public void ActivatePowerUp(PowerUpType type)
    {
        var PowerUp = PickedUpPowerUps.Where(p => p.GetPowerUpType == type).FirstOrDefault();
        
        player.ActivatePowerUp(PowerUp);
        StartCoroutine(player.DectivatePowerUp(PowerUp));

        PickedUpPowerUps.Remove(PowerUp);
    }
}
