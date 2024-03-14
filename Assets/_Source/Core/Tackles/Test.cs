using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class Test : MonoBehaviour
{

    public RodModel ModelRod;
    public ReelModel ModelReel;
    
    void Start()
    {
        FishingSet s = new FishingSet(new Rod(ModelRod, 12));
        s[TackleType.Reel] = new Reel(ModelReel, 13);
        Debug.Log(s.Reel.GetModel().Visual.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
