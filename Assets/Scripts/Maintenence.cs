using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Maintenence : MonoBehaviour
{
    public ResourceBundle DailyMaintenence;

    private void Start()
    {
        GameClock.OnTick += OnTick;
    }

    private void OnDisable()
    {
        GameClock.OnTick -= OnTick;
    }

    private void OnTick(object sender, GameClock.OnTickEventArgs e)
    {
        if (e.time == 0)
            Maintain();
    }

    void Maintain()
    {
        if (GetComponent<Inventory>().TryPurchase(DailyMaintenence) == false)
            Die();
    }

    void Die()
    {
        Debug.Log("Sorry! I died!");
        Destroy(gameObject);
    }

}
