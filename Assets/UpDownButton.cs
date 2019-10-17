using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownButton : MonoBehaviour
{
    public bool isPressedDown = false;
    public bool isPressedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPressedDown = false;
        isPressedUp = false;
    }
    public void PressDown()
    {
        isPressedDown = true;
    }
    public void PressUp()
    {
        isPressedUp = true;
    }
}
