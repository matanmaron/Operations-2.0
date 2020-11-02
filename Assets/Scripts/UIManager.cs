using Operations.Core;
using Operations.UI;
using SFB;
using System;
using TMPro;
using UnityEngine;

namespace Operations.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Canvas canvas = null;
        [SerializeField] GameObject RowPrefab = null;
        [SerializeField] GameObject CallPrefab = null;
        [SerializeField] Transform Content = null;
        [SerializeField] GameObject NewReshumaPanel = null;
        [SerializeField] GameObject NewCallPanel = null;
        [SerializeField] GameObject DataPathPanel = null;
        [SerializeField] TextMeshProUGUI AddTMP = null;
        [SerializeField] TextMeshProUGUI ExitTMP = null;

        private const string ADD_RESHUMA = "הוסף חברה";
        private const string ADD_CALL = "הוסף שיחה";
        private const string EXIT = "יציאה";
        private const string BACK = "חזרה";

        private bool isCallScreen = false;

        private void Awake()
        {
            NewReshumaPanel.SetActive(false);
            NewCallPanel.SetActive(false);
            DataPathPanel.SetActive(false);
        }

        public void OnAddBTN()
        {
            if (isCallScreen)
            {
                var row = Instantiate(CallPrefab, Content);
                var call = GameManager.Instance.data.AddNewCall();
                row.GetComponent<RowCall>().Init(call);
            }
            else
            {
                var row = Instantiate(RowPrefab, Content);
                var resh = GameManager.Instance.data.AddNewReshuma();
                row.GetComponent<Row>().Init(resh);
            }
        }

        internal void ShowDataFilePath()
        {
            DataPathPanel.SetActive(true);
        }

        public void OnShowDataFilePath()
        {
            DataPathPanel.SetActive(false);
            var paths = StandaloneFileBrowser.OpenFolderPanel("Select Data Folder", string.Empty, false);
            GameManager.Instance.SetPath(paths[0]);
            GameManager.Instance.LoadApp();
        }

        internal void ChangeToReshumas()
        {
            throw new NotImplementedException();
        }

        internal void ChangeToCalls()
        {
            RefreshCallsUI();
        }

        public void OnExitBTN()
        {
            if (isCallScreen)
            {
                RefreshReshumasUI();
            }
            else
            {
                LogManager.Log("Application quitting...");
                Application.Quit();
            }
        }

        private void LoadReshumaRow(Reshuma resh)
        {
            var row = Instantiate(RowPrefab, Content);
            row.GetComponent<Row>().Init(resh);
        }

        private void LoadCallRow(Call call)
        {
            var row = Instantiate(CallPrefab, Content);
            row.GetComponent<RowCall>().Init(call);
        }

        internal void RefreshReshumasUI()
        {
            AddTMP.text = ADD_RESHUMA;
            ExitTMP.text = EXIT;
            isCallScreen = false;
            foreach (Transform child in Content)
            {
                Destroy(child.gameObject);
            }
            foreach (Reshuma resh in GameManager.Instance.data.reshumas)
            {
                if (!resh.IsDeleted)
                {
                    LoadReshumaRow(resh);
                }
            }
        }

        internal void RefreshCallsUI()
        {
            AddTMP.text = ADD_CALL;
            ExitTMP.text = BACK;
            isCallScreen = true;
            var resh = GameManager.Instance.GetCurrentReshuma();
            if (resh == null)
            {
                LogManager.Log("Cannot find selected reshuma", LogType.Error);
                return;
            }
            foreach (Transform child in Content)
            {
                Destroy(child.gameObject);
            }
            foreach (Call call in resh.Calls)
            {
                if (!call.IsDeleted)
                {
                    LoadCallRow(call);
                }
            }
        }

        internal void ShowCallEdit()
        {
            NewCallPanel.SetActive(true);
        }

        internal void ShowReshumaEdit()
        {
            NewReshumaPanel.SetActive(true);
        }
    }
}