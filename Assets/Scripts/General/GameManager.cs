using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public Logging Logger;

    public GameState GameState;

    public bool TerminalOn = false;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            Logger = Instance.GetComponentInParent<Logging>();
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            TerminalOn = !TerminalOn;
        }
        UpdateGUI();
    }

    private void UpdateGUI()
    {
        Logger.Output.enabled = TerminalOn;
    }
}

public enum GameState
{
    Normal,
    Inventory,
    Dialog
}
