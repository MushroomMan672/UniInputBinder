using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputAction
{
    Jump,
}
public static class InputConfig
{

    public static Dictionary<InputAction, KeyCode> keyCodeMappings = new Dictionary<InputAction, KeyCode>
    {
        {InputAction.Jump, KeyCode.Space },

    };

    public static Dictionary<InputAction, string> gamePadMappings = new Dictionary<InputAction, string>
    {
        {InputAction.Jump, "joystick button 0"},

    };
}

