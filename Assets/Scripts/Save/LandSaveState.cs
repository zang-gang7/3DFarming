using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LandSaveState
{
    public Land.LandStatus landStatus;
    public GameTimestamp lastWatered;

    public LandSaveState(Land.LandStatus landStatus, GameTimestamp lastWatered)
    {
        this.landStatus = landStatus;
        this.lastWatered = lastWatered;
    }

     public void ClockUpadate(GameTimestamp timestamp)
    {
        // Checked if 24 hours had passed since last watered
        if(landStatus == Land.LandStatus.Watered)
        {
            // Hours since the land was watered
            int hoursElapsed = GameTimestamp.CompareTimestamps(lastWatered, timestamp);

            if(hoursElapsed > 24)
            {
                // Dry up (Switch back to farmland)
                landStatus = Land.LandStatus.Farmland ;
            }
        }
    }
}
