using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour
{
    public Text states;

    void Awake()
    {
        // Garante a referência ao componente de texto caso não tenha sido arrastado no Inspector
        if (states == null)
        {
            states = this.GetComponent<Text>();
        }
    }

    void LateUpdate()
    {
        if (states == null) return;

        Dictionary<string, int> worldstates = GWorld.Instance.GetWorld().GetStates();
        states.text = "";

        // Percorre todos os estados globais do mundo
        foreach (KeyValuePair<string, int> s in worldstates)
        {
            states.text += s.Key + ": " + s.Value + "\n";
        }
    }
}