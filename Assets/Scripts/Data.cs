using Enums;
using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;
using LogType = Enums.LogType;

namespace Operations
{
    [Serializable]
    public class Data
    {
        public List<Reshuma> reshumas = new List<Reshuma>();

        public Reshuma AddNewReshuma()
        {
            var resh = new Reshuma();
            resh.Calls = new List<Call>();
            reshumas.Add(resh);
            return resh;
        }

        public void RemoveReshuma(Guid guid)
        {
            var resh = reshumas.FirstOrDefault(x => x.ReshumaGuid == guid);
            if (resh != null)
            {
                resh.IsDeleted = true;
            }
            else
            {
                LogManager.Log($"Cannot find reshuma {guid}", LogType.ERROR);
            }
        }
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
                LogManager.Log("no data file found, creating default", Enums.LogType.WARNING);
                return null;
            }
            string jsonImport = File.ReadAllText($"{Application.dataPath}/{FileName}");
            if (jsonImport == "{}")
            {
                LogManager.Log("data file empty, creating default", Enums.LogType.WARNING);
                return null;
            }
            return JsonUtility.FromJson<Data>(jsonImport);
        }

        static void ExportData(Data data)
        {
            string jsonExport = JsonUtility.ToJson(data);
            File.WriteAllText($"{Application.dataPath}/{FileName}", jsonExport);
            LogManager.Log("data exported successfully", Enums.LogType.DEBUG);
        }

        internal static void Export(Data data)
        {
            ExportData(data);
        }
    }
}