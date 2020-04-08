using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupScript : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad() {
        LogManager.LogDebug("Application Startup");
        PlatformSelector();
    }

    private static void PlatformSelector()
    {
        // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            LogManager.LogDebug("Loading IOS");
            SceneManager.LoadScene("IOS");
        }
        else
        {
            LogManager.LogDebug("Loading GENERIC");
            SceneManager.LoadScene("GENERIC");
        }
    }
}
