using Operations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] UIManager uiManager = null;
        [SerializeField] AudioManager audioManager = null;
        internal Settings settings = null;
        internal Data data = null;
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
        private void Start()
        {
            settings = SettingsManager.GetSettings();
            data = DataManager.GetData();
            uiManager.RefreshUI();
        }

        internal void OnExit()
        {
            DataManager.Export(data);
        }
    }
}