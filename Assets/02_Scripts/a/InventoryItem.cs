using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInventoryItem
{
    string Name { get; }

    Sprite Image { get; }

    void OnPickup();

    void Ondrop();
    void OnUse();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}
