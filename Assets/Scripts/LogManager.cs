using Enums;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Managers
{
    public static class LogManager
    {
        private const string FileName = "Log.log";
        public static void Log(string str, Enums.LogType enumLog = Enums.LogType.DEBUG, [CallerFilePath] string className = "", [CallerMemberName] string functionName = "")
        {
            StringBuilder output = new StringBuilder();
            output.Append("[");
            output.Append(DateTime.UtcNow);
            output.Append(" (UTC)] - [");
            output.Append(enumLog);
            output.Append("] - [");
            output.Append(className.Substring(className.LastIndexOf("Scripts\\") + "Scripts\\".Length));
            output.Append("] - [");
            output.Append(functionName);
            output.Append("]:\t");
            output.Append(str);
            output.Append(Environment.NewLine);
            if (GameManager.Instance.settings == null || GameManager.Instance.settings.ShowDebug)
            {
                switch (enumLog)
                {
                    case Enums.LogType.WARNING:
                        Debug.LogWarning(output.ToString());
                        break;
                    case Enums.LogType.ERROR:
                        Debug.LogError(output.ToString());
                        break;
                    case Enums.LogType.DEBUG:
                    default:
                        Debug.Log(output.ToString());
                        break;
                }
            }
            if (GameManager.Instance.settings == null || GameManager.Instance.settings.SaveDebug)
            {
                File.AppendAllText($"{Application.dataPath}/{FileName}", output.ToString());
            }
        }
    }
}