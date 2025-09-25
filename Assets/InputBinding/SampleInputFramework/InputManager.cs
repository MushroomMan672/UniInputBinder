using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    /// <summary>
    /// 按键刚按下的那一帧 返回 true，只在按下的第一帧触发
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public static bool GetActionDown(InputAction action)
    {
        string gamePadKey = InputData.GetKey_GamePad(action);
        if (!string.IsNullOrEmpty(gamePadKey) && Input.GetKeyDown(gamePadKey))
            return true;

        KeyCode key = InputData.GetKey_Keyboard(action);
        return Input.GetKeyDown(key);
    }
    /// <summary>
    /// 按键是否被按下，每一帧都会检测，如果持续按住返回 true
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public static bool GetAction(InputAction action)
    {
        string gamePadKey = InputData.GetKey_GamePad(action);
        if (!string.IsNullOrEmpty(gamePadKey) && Input.GetKey(gamePadKey))
            return true;

        KeyCode key = InputData.GetKey_Keyboard(action);
        return Input.GetKey(key);
    }
    /// <summary>
    /// 按键刚松开的那一帧 返回 true，只在释放的那一帧触发
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public static bool GetActionUp(InputAction action)
    {
        string gamePadKey = InputData.GetKey_GamePad(action);
        if (!string.IsNullOrEmpty(gamePadKey) && Input.GetKeyUp(gamePadKey))
            return true;

        KeyCode key = InputData.GetKey_Keyboard(action);
        return Input.GetKeyUp(key);
    }
}
