using Enums;
using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Operations
{
    [Serializable]
    public class Data
    {
        public List<Reshuma> reshumas = new List<Reshuma>();
    }

    public static class DataManager
    {
        private const string FileName = "data.json";
        public static Data GetData()
        {
            Data data = ImportData();
            if (data == null)
            {
                var tmp = new Data();
                ExportData(tmp);
                return tmp;
            }
            return data;
        }

        static Data ImportData()
        {
            if (!File.Exists($"{Application.dataPath}/{FileName}"))
            {
                LogManager.Log("no data file found, creating default", EnumLog.WARNING);
                return null;
            }
            string jsonImport = File.ReadAllText($"{Application.dataPath}/{FileName}");
            if (jsonImport == "{}")
            {
                LogManager.Log("data file empty, creating default", EnumLog.WARNING);
                return null;
            }
            return JsonUtility.FromJson<Data>(jsonImport);
        }

        static void ExportData(Data data)
        {
            string jsonExport = JsonUtility.ToJson(data);
            File.WriteAllText($"{Application.dataPath}/{FileName}", jsonExport);
            LogManager.Log("data exported successfully", EnumLog.DEBUG);
        }

        internal static void Export(Data data)
        {
            ExportData(data);
        }
    }
}