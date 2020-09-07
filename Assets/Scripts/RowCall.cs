using Operations.Core;
using Operations.Managers;
using TMPro;
using UnityEngine;

namespace Operations.UI
{
    public class RowCall : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text = null;
        Call call = null;

        public void Init(Call _call)
        {
            call = _call;
            text.text = call.ToString();
        }

        public void OnDelete()
        {
            GameManager.Instance.RemoveCall(call.CallGuid);
            Destroy(gameObject);
        }

        public void OnEdit()
        {
            GameManager.Instance.ShowCallEdit(call);
        }
    }
}