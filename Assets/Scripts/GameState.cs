using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour, ITimeTracker
{
    public static GameStateManager Instance { get; private set; }

    private void Awake()
    {
        // If there is more than one instance, destory the extra
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            // Set the static instance to this instance
            Instance = this;
        }
    }

    void Start()
    {
        // Add this to TimeManager's Listener list
        TimeManager.Instance.RegisterTracker(this);
    }

    public void ClockUpadate(GameTimestamp timestamp)
    {
        throw new System.NotImplementedException();
    }
}
