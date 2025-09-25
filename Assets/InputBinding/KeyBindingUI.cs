using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindingUI : MonoBehaviour
{
    [SerializeField] private InputAction action;
    [SerializeField] private Button bindButton;
    [SerializeField] private TextMeshProUGUI actionText;
    [SerializeField] private TextMeshProUGUI bindText;

    private bool isWaitingForKey = false;

    private void Start()
    {
        UpdateBindText();
        bindButton.onClick.AddListener(StartRebind);
    }

    private void StartRebind()
    {
        actionText.text = $"{action}";
        bindText.text = "[请按键...]";
        isWaitingForKey = true;
        StartCoroutine(WaitForKey());
    }

    private IEnumerator WaitForKey()
    {
        while (isWaitingForKey)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode k in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(k))
                    {
                        InputData.SetKey_Keyboard(action, k);
                        InputData.Save();
                        isWaitingForKey = false;
                        UpdateBindText();
                        yield break;
                    }
                }
            }
            yield return null;
        }
    }

    private void UpdateBindText()
    {
        actionText.text = $"{action}";
        bindText.text = $"[{InputData.GetKey_Keyboard(action)}]";
    }
}
