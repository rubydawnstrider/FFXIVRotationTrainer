using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybind 
{
    public string Name { get; set; }
    public KeyCode KeyCode { get; set; }
    public KeyModifier Modifier { get; set; }
    public HotbarSlot HotbarSlot{ get; set; }
}
