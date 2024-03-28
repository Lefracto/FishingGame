using System;
using UnityEngine;

public class SpotsPanel : SimplePanel
{
    private Action<int> _onLoadSpot;

    public void AddLoadSpotHandler(Action<int> handler)
        => _onLoadSpot += handler;
    
 
    public void LoadSpot(int spotId)
    {
        _onLoadSpot.Invoke(spotId);
    }
    
}
