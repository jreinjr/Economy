using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ResourceBundle currentStorage;
    public ResourceBundle maxStorage;
    //public bool IsFull { get; protected set; }

    public bool Add(ResourceBundle newBundle)
    {
        var newStorage = currentStorage + newBundle;

        if (newStorage.FitsWithin(maxStorage) == false)
            return false;

        currentStorage += newBundle;
        return true;
    }

    public bool CanAfford(ResourceBundle cost)
    {
        return (cost.FitsWithin(currentStorage));
    }

    public bool TryPurchase(ResourceBundle cost)
    {
        if (!CanAfford(cost))
            return false;

        currentStorage -= cost;
        return true;
    }
}
