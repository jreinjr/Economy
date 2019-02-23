using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameClock : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs
    {
        public uint tick;
        public uint time;
    }
    public static event EventHandler<OnTickEventArgs> OnTick;

    [SerializeField]
    [ReadOnly]
    private uint time;

    public uint startTime;

    private uint tick;
    private float tickTimer;
    public float tickTimerMax = .2f;

    private void Awake()
    {
        tick = 0;
        time = startTime;
        tickTimer = 0;
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= tickTimerMax)
        {
            tickTimer -= tickTimerMax;
            tick++;
            time++;
            time %= 24;
            OnTick?.Invoke(this, new OnTickEventArgs { tick = tick, time = time });
        }
    }
}
