using Operations.Core;
using Operations.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Operations.Data
{
    [Serializable]
    public class Data
    {
        public List<Reshuma> reshumas = new List<Reshuma>();
        public Reshuma AddNewReshuma()
        {
            var resh = new Reshuma();
            reshumas.Add(resh);
            return resh;
        }

        public Call AddNewCall()
        {
            var call = new Call();
            GameManager.Instance.GetCurrentReshuma().Calls.Add(call);
            GameManager.Instance.GetCurrentReshuma().Calls.OrderBy(x => x.DealEndTicks);
            return call;
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
                LogManager.Log($"Cannot find reshuma {guid}", LogType.Error);
            }
        }

        public void RemoveCall(Reshuma resh, Guid callGuid)
        {
            var call = resh.Calls.FirstOrDefault(x => x.CallGuid == callGuid);
            if (call != null)
            {
                call.IsDeleted = true;
            }
            else
            {
                LogManager.Log($"Cannot find call {callGuid}", LogType.Error);
            }
        }
    }

    public static class DataManager
    {
        private const string FileName = "OperationData.json";
        public static string PATH = $"{Application.dataPath}";

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
            if (!File.Exists($"{PATH}/{FileName}"))
            {
                LogManager.Log("no data file found, creating default", LogType.Warning);
                return null;
            }
            string jsonImport = File.ReadAllText($"{PATH}/{FileName}");
            if (jsonImport == "{}")
            {
                LogManager.Log("data file empty, creating default", LogType.Warning);
                return null;
            }
            return JsonUtility.FromJson<Data>(jsonImport);
        }

        static void ExportData(Data data)
        {
            string jsonExport = JsonUtility.ToJson(data);
            File.WriteAllText($"{PATH}/{FileName}", jsonExport);
            LogManager.Log("data exported successfully", LogType.Log);
        }

        internal static void Export(Data data)
        {
            ExportData(data);
        }
    }
}