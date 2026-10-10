using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(GAgentVisualizer))]
[CanEditMultipleObjects]
public class GAgentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();

        GAgentVisualizer agent = (GAgentVisualizer)target;

        if (agent.thisAgent == null)
        {
            agent.thisAgent = agent.GetComponent<GAgent>();
        }

        if (agent.thisAgent == null)
            return;

        GUILayout.Space(10);
        GUILayout.Label("Name: " + agent.name, EditorStyles.boldLabel);
        GUILayout.Label("Current Action: " + (agent.thisAgent.currentAction != null ? agent.thisAgent.currentAction.actionName : "None"));

        GUILayout.Space(5);
        GUILayout.Label("Actions:", EditorStyles.boldLabel);
        if (agent.thisAgent.actions != null)
        {
            foreach (GAction a in agent.thisAgent.actions)
            {
                GUILayout.Label("    " + a.actionName);
            }
        }

        GUILayout.Space(5);
        GUILayout.Label("Goals:", EditorStyles.boldLabel);
        if (agent.thisAgent.goals != null)
        {
            foreach (KeyValuePair<SubGoal, int> g in agent.thisAgent.goals)
            {
                foreach (KeyValuePair<string, int> sg in g.Key.sGoals)
                {
                    GUILayout.Label("    " + sg.Key + ": " + sg.Value);
                }
            }
        }

        GUILayout.Space(5);
        GUILayout.Label("World States (Global):", EditorStyles.boldLabel);
        Dictionary<string, int> worldStates = GWorld.Instance.GetWorld().GetStates();
        foreach (KeyValuePair<string, int> ws in worldStates)
        {
            GUILayout.Label("    " + ws.Key + ": " + ws.Value);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
