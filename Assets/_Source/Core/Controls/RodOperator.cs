using Presentation.Panels;
using Presentation.Views.Lower;
using UnityEngine;

namespace Core
{
  public class RodOperator : MonoBehaviour 
  {
    // private int _currentRod = 0;
    // private List<FishingSet> _fishingSets;
    
    public SpotBackPanel Panel;
    
    private FishingSet _currentSet;
    
    public bool RetrieveRod(FishingSet fishingSet)
    {
      if (fishingSet == null)
        return false;
      
      for (int i = 0; i < 4; i++)
      {
        if (fishingSet[(TackleType)i] == null)
          return false;
      }

      Panel.IsAllowedToSpawn = true;
      BaitSelectView.IsBase = false;
      return true;
    }

    public void ReturnRod()
    {
    }
  }
}