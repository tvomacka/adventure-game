using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class Logging : MonoBehaviour
{
    public TextMeshProUGUI Output;
    public List<string> Events = new List<string>();
    public int LogSize = 20;

    private bool _dirty = true;

    // Update is called once per frame
    void Update()
    {
        if (_dirty && Output != null)
        {
            Output.text = "";
            for (int i = Math.Max(0, Events.Count - LogSize); i < Events.Count; i++)
            {
                Output.text += $"> {Events[i]}\n";
            }

            _dirty = false;
        }
    }

    public void Log(string message)
    {
        Events.Add(message);
        _dirty = true;
    }
}
