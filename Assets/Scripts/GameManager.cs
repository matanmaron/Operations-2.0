using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager = null;
    internal List<Reshuma> reshumas = null;

    public static GameManager Instance { get; private set; } //singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        reshumas = new List<Reshuma>();
    }

    public void AddNewReshuma()
    {
        var row = new Reshuma();
        reshumas.Add(row);
        uiManager.AddNewReshuma(row);
    }
}