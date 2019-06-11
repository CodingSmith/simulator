/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using UnityEngine;
using UnityEditor;
using Simulator.Map;

[CustomEditor(typeof(MapPedestrian)), CanEditMultipleObjects]
public class MapPedestrianEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MapPedestrian mapLane = (MapPedestrian)target;

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        if (GUILayout.Button("Append Point"))
        {
            //Undo.RecordObject(mapData, "change builder");
            //mapData.AppendPoint();
        }

        if (GUILayout.Button("Prepend Point"))
        {
            //Undo.RecordObject(mapSegment, "change builder");
            //mapSegment.PrependPoint();
        }

        if (GUILayout.Button("Remove First"))
        {
            //Undo.RecordObject(mapSegment, "change builder");
            //mapSegment.RemoveFirstPoint();
        }

        if (GUILayout.Button("Remove Last"))
        {
            //Undo.RecordObject(mapSegment, "change builder");
            //mapSegment.RemoveLastPoint();
        }

        if (GUILayout.Button("Reverse Points"))
        {
            //Undo.RecordObject(mapSegment, "change builder");
            //mapSegment.ReversePoints();
        }

        if (GUILayout.Button("Reset Points"))
        {
            //Undo.RecordObject(mapSegment, "change builder");
            //mapSegment.ResetPoints();
        }

        if (GUILayout.Button("Reset Transform"))
        {
            //Undo.RecordObject(mapSegment, "change builder");
            //mapSegment.ResetPoints();
        }

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        if (GUILayout.Button("Double Waypoint Resolution"))
        {
            //Undo.RecordObject(mapSegment, "change builder");
            //if (!mapSegment.DoubleSubsegments())
            //{
            //    Debug.Log($"{nameof(mapSegment.DoubleSubsegments)} fail");
            //}
        }

        if (GUILayout.Button("Half Waypoint Resolution"))
        {
            //Undo.RecordObject(mapSegment, "change builder");
            //if (!mapSegment.HalfSubsegments())
            //{
            //    Debug.Log($"{nameof(mapSegment.HalfSubsegments)} fail");
            //}
        }
    }

    protected virtual void OnSceneGUI()
    {
        MapPedestrian vmMapPed = (MapPedestrian)target;
        if (vmMapPed.mapLocalPositions.Count < 1)
            return;

        if (vmMapPed.displayHandles)
        {
            for (int i = 0; i < vmMapPed.mapLocalPositions.Count; i++)
            {
                EditorGUI.BeginChangeCheck();
                Vector3 newTargetPosition = Handles.PositionHandle(vmMapPed.transform.TransformPoint(vmMapPed.mapLocalPositions[i]), vmMapPed.transform.rotation);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(vmMapPed, "Pedestrian points change");
                    vmMapPed.mapLocalPositions[i] = vmMapPed.transform.InverseTransformPoint(newTargetPosition);
                }
            }
        }
    }
}