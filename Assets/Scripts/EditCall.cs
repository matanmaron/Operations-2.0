using Operations.Core;
using Operations.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Operations.UI
{
    public class EditCall : MonoBehaviour
    {
        [SerializeField] TMP_InputField RepresentativeTMP = null;
        [SerializeField] TMP_InputField ContentsTMP = null;
        [SerializeField] TMP_InputField callDateTMP = null;
        [SerializeField] TMP_InputField dealEndTMP = null;

        private Call call = null;
        private void OnEnable()
        {
            call = GameManager.Instance.GetCurrentCall();
            if (call == null)
            {
                LogManager.Log("cannot find call", Enums.LogType.ERROR);
            }
            RepresentativeTMP.text = call.Representative;
            ContentsTMP.text = call.Contents;
            callDateTMP.text = call.CallDate.ToShortDateString();
            dealEndTMP.text = call.DealEnd.ToShortDateString();
        }

        public void OnOkBTN()
        {
            call.Representative = RepresentativeTMP.text;
            call.Contents = ContentsTMP.text;
            call.CallDate = TryPharseDate(callDateTMP.text);
            call.DealEnd = TryPharseDate(dealEndTMP.text);
            gameObject.SetActive(false);
            GameManager.Instance.uiManager.RefreshCallsUI();
        }

        DateTime TryPharseDate(string date)
        {
            DateTime res;
            if (DateTime.TryParse(date, out res))
            {
                return res;
            }
            LogManager.Log($"error pharsing date: {date}");
            return DateTime.Now;
        }
    }
}