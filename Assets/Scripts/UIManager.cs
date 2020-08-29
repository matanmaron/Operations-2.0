using Operations;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Canvas canvas = null;
        [SerializeField] GameObject RowPrefab = null;
        [SerializeField] Transform Content = null;

        public void OnAddBTN()
        {
            var row = Instantiate(RowPrefab, Content);
            var resh = GameManager.Instance.data.AddNewReshuma();
            row.GetComponent<Row>().Init(resh);
        }

        public void OnExitBTN()
        {
            LogManager.Log("Application quitting...");
            GameManager.Instance.OnExit();
            Application.Quit();
        }

        public void LoadRow(Reshuma resh)
        {
            var row = Instantiate(RowPrefab, Content);
            row.GetComponent<Row>().Init(resh);
        }

        public void RefreshUI()
        {
            foreach (Transform child in Content)
            {
                Destroy(child.gameObject);
            }
            foreach (Reshuma resh in GameManager.Instance.data.reshumas)
            {
                if (!resh.IsDeleted)
                {
                    LoadRow(resh);
                }
            }
        }
    }
}