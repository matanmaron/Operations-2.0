using Operations.Core;
using Operations.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Operations.UI
{
    public class EditReshuma : MonoBehaviour
    {
        [SerializeField] TMP_InputField companyTMP = null;
        [SerializeField] TMP_InputField typeTMP = null;
        [SerializeField] TMP_InputField phoneTMP = null;

        private Reshuma resh = null;
        private void OnEnable()
        {
            resh = GameManager.Instance.GetCurrentReshuma();
            if (resh == null)
            {
                LogManager.Log("cannot find reshuma", LogType.Error);
            }
            companyTMP.text = resh.Company;
            typeTMP.text = resh.Type;
            phoneTMP.text = resh.PhoneNumber;
        }

        public void OnOkBTN()
        {
            resh.Company = companyTMP.text;
            resh.Type = typeTMP.text;
            resh.PhoneNumber = phoneTMP.text;
            gameObject.SetActive(false);
            GameManager.Instance.uiManager.RefreshReshumasUI();
        }
    }
}