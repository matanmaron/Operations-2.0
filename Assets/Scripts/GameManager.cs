using Operations.Data;
using Operations.Core;
using System;
using UnityEngine;

namespace Operations.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] AudioManager audioManager = null;
        [SerializeField] internal UIManager uiManager = null;
        internal Settings settings = null;
        internal Data.Data data = null;
        private Reshuma SelectedReshuma = null;
        private Call SelectedCall = null;

        public static GameManager Instance { get; private set; } //singleton
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        internal void RemoveCall(Guid callGuid)
        {
            data.RemoveCall(SelectedReshuma, callGuid);
        }

        private void Start()
        {
            settings = SettingsManager.GetSettings();
            if (settings.Path == string.Empty)
            {
                uiManager.ShowDataFilePath();
            }
            else
            {
                LoadApp();
            }

        }

        internal void LoadApp()
        {
            SetPath(settings.Path);
            data = DataManager.GetData();
            uiManager.RefreshReshumasUI();
            SettingsManager.Save(settings);
        }

        internal void SetSelectedReshuma(Reshuma resh)
        {
            SelectedReshuma = resh;
        }

        internal void ShowReshumanEdit(Reshuma resh)
        {
            SelectedReshuma = resh;
            uiManager.ShowReshumaEdit();
        }

        internal void ShowCallEdit(Call call)
        {
            SelectedCall = call;
            uiManager.ShowCallEdit();
        }

        internal Call GetCurrentCall()
        {
            return SelectedCall;
        }

        internal void SetPath(string val)
        {
            if (val == string.Empty)
            {
                LogManager.Log("path is empty. reverting to default",LogType.Warning);
                val = DataManager.PATH;
            }
            if (settings.Path != val)
            {
                settings.Path = val;
            }
            DataManager.PATH = val;
        }

        internal Reshuma GetCurrentReshuma()
        {
            return SelectedReshuma;
        }

        private void OnApplicationQuit()
        {
            DataManager.Export(data);
        }
    }
}