using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Base : ScriptableObject
{
    Panel_Dialogue panel;
    // Start is called before the first frame update
    public void init(Panel_Dialogue _panel)
    {
        panel = _panel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
