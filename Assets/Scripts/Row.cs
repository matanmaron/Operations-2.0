using Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Operations
{
    public class Row : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text = null;
        Reshuma resh = null;

        public void Init(Reshuma _resh)
        {
            resh = _resh;
            resh.Company = resh.ReshumaGuid.ToString();
            text.text = resh.ToString();
        }

        public void OnDelete()
        {
            GameManager.Instance.data.RemoveReshuma(resh.ReshumaGuid);
            Destroy(gameObject);
        }

        public void OnEdit()
        {

        }
    }
}