using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeathPack : InventoryItemBase
{
    public int Points;
    

    public Inventory _Inventory;

    private void Awake()
    {
        _Inventory = Inventory.FindObjectOfType<Inventory>();
    }
    public override void OnUse()
    {

        Player_Health.instance.IncDegHp("Hungry", Points);

        _Inventory.RemovedItemm(this);

        Destroy(this.gameObject);

    }
}
