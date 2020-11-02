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
        [SerializeField] TextMeshProUGUI errorMassage = null;
        private Call call = null;
        private bool error = false;

        private void OnEnable()
        {
            errorMassage.text = string.Empty;
            call = GameManager.Instance.GetCurrentCall();
            if (call == null)
            {
                LogManager.Log("cannot find call", LogType.Error);
            }
            RepresentativeTMP.text = call.Representative;
            ContentsTMP.text = call.Contents;
            callDateTMP.text = new DateTime(call.CallDateTicks).ToShortDateString();
            dealEndTMP.text = new DateTime(call.DealEndTicks).ToShortDateString();
        }

        public void OnOkBTN()
        {
            errorMassage.text = string.Empty;
            call.Representative = RepresentativeTMP.text;
            call.Contents = ContentsTMP.text;
            call.CallDateTicks = TryPharseDate(callDateTMP.text).Ticks;
            call.DealEndTicks = TryPharseDate(dealEndTMP.text).Ticks;
            if (error)
            {
                return;
            }
            gameObject.SetActive(false);
            GameManager.Instance.uiManager.RefreshCallsUI();
        }

        DateTime TryPharseDate(string date)
        {
            DateTime res;
            if (DateTime.TryParse(date, out res))
            {
                error = false;
                
                return res;
            }
            ShowError($"תאריך {date} לא תקין");
            error = true;
            LogManager.Log($"error pharsing date: {date}");
            return DateTime.Now;
        }

        private void ShowError(string ex)
        {
            errorMassage.text = errorMassage.text + Environment.NewLine + ex;
        }
    }
}