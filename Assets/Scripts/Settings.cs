using Enums;
using System;
using System.IO;
using UnityEngine;

namespace Managers
{
    [Serializable]
    public class Settings
    {
        public bool ShowDebug = false;
        public bool SaveDebug = false;

        public override string ToString()
        {
            return $"ShowDebug:{ShowDebug} | SaveDebug:{SaveDebug}";
        }
    }

    public static class SettingsManager
    {
        private const string FileName = "settings.json";
        public static Settings GetSettings()
        {
            Settings settings = ImportSettings();
            if (settings == null)
            {
                var tmp = new Settings();
                ExportSettings(tmp);
                return tmp;
            }
            return settings;
        }

        static Settings ImportSettings()
        {
            if (!File.Exists($"{Application.dataPath}/{FileName}"))
            {
                LogManager.Log("no settings file found, creating default", EnumLog.WARNING);
                return null;
            }
            string jsonImport = File.ReadAllText($"{Application.dataPath}/{FileName}");
            if (jsonImport == "{}")
            {
                LogManager.Log("settings file empty, creating default", EnumLog.WARNING);
                return null;
            }
            return JsonUtility.FromJson<Settings>(jsonImport);
        }

        static void ExportSettings(Settings settings)
        {
            string jsonExport = JsonUtility.ToJson(settings);
            File.WriteAllText($"{Application.dataPath}/{FileName}", jsonExport);
            LogManager.Log("settings exported successfully", EnumLog.DEBUG);
        }

        internal static void Export(Settings settings)
        {
            ExportSettings(settings);
        }
    }
}