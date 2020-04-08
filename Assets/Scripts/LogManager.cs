using System;
using System.Text;
using UnityEngine;

public static class LogManager
{
    public static void LogDebug(string str)
    {
        StringBuilder output = new StringBuilder();
        output.Append("[DEBUG] - [");
        output.Append(DateTime.UtcNow);
        output.Append("(UTC)] : ");
        output.Append(str);
        Debug.Log(output.ToString());
    }
    public static void LogError(string str)
    {
        StringBuilder output = new StringBuilder();
        output.Append("[ERROR] - [");
        output.Append(DateTime.UtcNow);
        output.Append("(UTC)] : ");
        output.Append(str);
        Debug.Log(output.ToString());
    }
}
