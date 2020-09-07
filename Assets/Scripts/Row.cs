using Operations.Core;
using Operations.Managers;
using TMPro;
using UnityEngine;

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