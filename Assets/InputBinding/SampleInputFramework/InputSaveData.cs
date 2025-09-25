using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputSaveData
{
    public Dictionary<InputAction, KeyCode> keyMappings;
    public Dictionary<InputAction, string> gamePadMappings;
}



