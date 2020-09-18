using Operations.Core;
using Operations.Managers;
using System;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Operations.UI
{
    public class Row : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text = null;
        Reshuma resh = null;

        public void Init(Reshuma _resh)
        {
            resh = _resh;
            text.text = resh.ToString();
            CheckStatus();
        }

        private void CheckStatus()
        {
            var call = resh.Calls.LastOrDefault();
            if (call != null)
            {
                var end = new DateTime(call.DealEndTicks);
                if (end - DateTime.Now <= TimeSpan.Zero)
                {
                    //red
                    gameObject.GetComponent<Image>().color = Color.red;
                }
                else if (end - DateTime.Now <= TimeSpan.FromDays(30))
                {
                    //yellow
                    gameObject.GetComponent<Image>().color = Color.yellow;
                }
            }
        }

        public void OnDelete()
        {
            GameManager.Instance.data.RemoveReshuma(resh.ReshumaGuid);
            Destroy(gameObject);
        }

        public void OnEdit()
        {
            GameManager.Instance.ShowReshumanEdit(resh);
        }

        public void OnReshumaBTN()
        {
            GameManager.Instance.SetSelectedReshuma(resh);
            GameManager.Instance.uiManager.ChangeToCalls();
    }

    }
}