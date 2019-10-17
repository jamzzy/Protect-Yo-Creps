using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeSelect : MonoBehaviour
{
    static public int shoeSelection = 0;
   public int GetShoeSelection()
    {
        return shoeSelection;
    }
    public void SetShoeSelection(int shoe)
    {
        shoeSelection = shoe;
    }
}
