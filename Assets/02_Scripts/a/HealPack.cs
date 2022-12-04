
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealPack : InventoryItemBase
{
    public int HealthPoints;
    public int WaterPoints;
    public int MentalPoints;

    public Inventory _Inventory;

    public override void OnUse()
    {

        Player_Health.instance.IncDegHp("Hungry", HealthPoints);
        Player_Health.instance.IncDegHp("Water", WaterPoints);
        Player_Health.instance.IncDegHp("Mental", MentalPoints);

        _Inventory.RemovedItemm(this);

        Destroy(this.gameObject);

    }
}
