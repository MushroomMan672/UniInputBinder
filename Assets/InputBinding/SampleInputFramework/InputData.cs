using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public static class InputData
{
    private static readonly string SavePath = Path.Combine(Application.persistentDataPath, "InputBindings.json");
    private static Dictionary<InputAction, KeyCode> keyMappings
        = new Dictionary<InputAction, KeyCode>(InputConfig.keyCodeMappings);
    private static Dictionary<InputAction, string> gamePadMappings
        = new Dictionary<InputAction, string>(InputConfig.gamePadMappings);

    private static TValue GetMapping<TKey, TValue>(
        Dictionary<TKey, TValue> dict, TKey action, TValue defaultValue = default)
    {
        if (!dict.ContainsKey(action))
        {
            Debug.LogWarning($"[InputData]不存在的动作-{action}");
            return defaultValue;
        }
        return dict[action];
    }

    private static void SetMapping<TKey, TValue>(
        Dictionary<TKey, TValue> dict, TKey action, TValue newValue)
    {
        if (dict.ContainsKey(action))
        {
            dict[action] = newValue;
            Save();
        }

        else
            Debug.LogWarning($"[InputData]不能设置不存在的动作-{action}");
    }

    public static KeyCode GetKey_Keyboard(InputAction action)
        => GetMapping(keyMappings, action, KeyCode.None);

    public static string GetKey_GamePad(InputAction action)
        => GetMapping(gamePadMappings, action, null);


    public static void SetKey_Keyboard(InputAction action, KeyCode newKey)
        => SetMapping(keyMappings, action, newKey);


    public static void SetKey_GamePad(InputAction action, string newKey)
        => SetMapping(gamePadMappings, action, newKey);
    
    public static void Save()
    {
        var data = new InputSaveData
        {
            keyMappings = keyMappings,
            gamePadMappings = gamePadMappings
        };

        try
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(SavePath, json);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[InputData] 保存失败: {e}");
        }
    }

    public static void Load()
    {
        if (!File.Exists(SavePath)) return;

        try
        {
            string json = File.ReadAllText(SavePath);
            var data = JsonConvert.DeserializeObject<InputSaveData>(json);

            keyMappings = data.keyMappings ?? new Dictionary<InputAction, KeyCode>(InputConfig.keyCodeMappings);
            gamePadMappings = data.gamePadMappings ?? new Dictionary<InputAction, string>(InputConfig.gamePadMappings);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[InputData] 加载失败: {e}");
            // 出错用默认值
            keyMappings = new Dictionary<InputAction, KeyCode>(InputConfig.keyCodeMappings);
            gamePadMappings = new Dictionary<InputAction, string>(InputConfig.gamePadMappings);
        }
    }

}
