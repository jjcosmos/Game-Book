using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Connector : MonoBehaviour
{

    static Transform[] SelectedObjects;
    static StoryNode ParentNode;
    static StoryNode ChildNode;

    [MenuItem("MyTools/ConnectToMyNextSlot _m")]
    static void ConnectNextSlot()
    {
        SelectedObjects = Selection.transforms;
        if (CheckSelection())
        {
            Undo.RecordObject(ParentNode, $"Added {ChildNode} as a branch for {ParentNode}");
            if (ParentNode.Option1 == null)
            {
                ParentNode.Option1 = ChildNode;
            }
            else if (ParentNode.Option2 == null)
            {
                ParentNode.Option2 = ChildNode;
            }
            else if (ParentNode.Option3 == null)
            {
                ParentNode.Option3 = ChildNode;
            }
            else if (ParentNode.Option4 == null)
            {
                ParentNode.Option4 = ChildNode;
            }
            else if (ParentNode.Option5 == null)
            {
                ParentNode.Option5 = ChildNode;
            }
            Undo.FlushUndoRecordObjects();


            //Debug.Log($"{SelectedObjects[0].name} \n {SelectedObjects[1].name}");
        }
        
    }

    [MenuItem("MyTools/ConnectToSlot1 %&#1")]
    static void ConnectToSlot1()
    {
        var SelectedObjects = Selection.transforms;
        if (CheckSelection())
        {
            Undo.RecordObject(ParentNode, $"Added {ChildNode} as a branch for {ParentNode}");
            ParentNode.Option1 = ChildNode;
        }
    }
    [MenuItem("MyTools/ConnectToSlot2 %&#2")]
    static void ConnectToSlot2()
    {
        var SelectedObjects = Selection.transforms;
        if (CheckSelection())
        {
            Undo.RecordObject(ParentNode, $"Added {ChildNode} as a branch for {ParentNode}");
            ParentNode.Option2 = ChildNode;
        }
    }

    [MenuItem("MyTools/ConnectToSlot3 %&#3")]
    static void ConnectToSlot3()
    {
        var SelectedObjects = Selection.transforms;
        if (CheckSelection())
        {
            Undo.RecordObject(ParentNode, $"Added {ChildNode} as a branch for {ParentNode}");
            ParentNode.Option3 = ChildNode;
        }
    }

    [MenuItem("MyTools/ConnectToSlot4 %&#4")]
    static void ConnectToSlot4()
    {
        var SelectedObjects = Selection.transforms;
        if (CheckSelection())
        {
            Undo.RecordObject(ParentNode, $"Added {ChildNode} as a branch for {ParentNode}");
            ParentNode.Option4 = ChildNode;
        }
    }

    [MenuItem("MyTools/ConnectToSlot5 %&#5")]
    static void ConnectToSlot5()
    {
        var SelectedObjects = Selection.transforms;
        if (CheckSelection())
        {
            Undo.RecordObject(ParentNode, $"Added {ChildNode} as a branch for {ParentNode}");
            ParentNode.Option5 = ChildNode;
            
        }
    }

    private static bool CheckSelection()
    {
        //Debug.Log("CehckSelection");
        SelectedObjects = Selection.transforms;
        if (SelectedObjects.Length == 2 && SelectedObjects[0].GetComponent<StoryNode>() && SelectedObjects[1].GetComponent<StoryNode>())
        {


            if (SelectedObjects[0] != Selection.activeTransform)
            {
                Transform temp = SelectedObjects[0];
                SelectedObjects[0] = SelectedObjects[1];
                SelectedObjects[1] = temp;
            }

            ParentNode = SelectedObjects[1].GetComponent<StoryNode>();
            ChildNode = SelectedObjects[0].GetComponent<StoryNode>();

            return true;
        }
        else
        {
            Debug.LogWarning("Invalid Selection for Link");
        }
        return false;
    }

    [MenuItem("MyTools/ClearAllSlots %&#m")]
    static void ClearAllSlots()
    {
        if(Selection.activeTransform != null && Selection.activeTransform.GetComponent<StoryNode>())
        {
            Transform active = Selection.activeTransform;
            ParentNode = active.GetComponent<StoryNode>();
            Undo.RecordObject(ParentNode, $"Cleared {ParentNode}");
            ParentNode.Option1 = null;
            ParentNode.Option2 = null;
            ParentNode.Option3 = null;
            ParentNode.Option4 = null;
            ParentNode.Option5 = null;
            Debug.Log($"Cleared {active.name}");

            if(Selection.transforms.Length > 1)
            {
                Debug.LogWarning($"Did you mean to clear {active.name}? Multiple objects are selected");
            }
        }
        
    }


    [MenuItem("MyTools/Add New As Next Link")]
    public static void DuplicateSelected()
    {
        Object prefabRoot = PrefabUtility.GetCorrespondingObjectFromSource(Selection.activeTransform.gameObject);

        if (prefabRoot != null)
        {
            GameObject obj = PrefabUtility.InstantiatePrefab(prefabRoot) as GameObject;
            obj.transform.position = Selection.activeTransform.position + new Vector3(0, 0, 5);
            ParentNode =  Selection.activeTransform.GetComponent<StoryNode>();
            ChildNode = obj.GetComponent<StoryNode>();


            if (ParentNode.Option1 == null)
            {
                ParentNode.Option1 = ChildNode;
            }
            else if (ParentNode.Option2 == null)
            {
                ParentNode.Option2 = ChildNode;
            }
            else if (ParentNode.Option3 == null)
            {
                ParentNode.Option3 = ChildNode;
            }
            else if (ParentNode.Option4 == null)
            {
                ParentNode.Option4 = ChildNode;
            }
            else if (ParentNode.Option5 == null)
            {
                ParentNode.Option5 = ChildNode;
            }
            Undo.RegisterCreatedObjectUndo(obj, "Create Linked Node");
        }
        else
        {
            Debug.LogError("FAIL LULW");
        }
    }

    [MenuItem("MyTools/Add Blank 4")]
    public static void AddBlank4()
    {
        Object prefabRoot = PrefabUtility.GetCorrespondingObjectFromSource(Selection.activeTransform.gameObject);
        GameObject obj = null;
        int j = -2;
        for (int i = 0; i < 4; i++)
        {
            if (prefabRoot != null)
            {
                obj = PrefabUtility.InstantiatePrefab(prefabRoot) as GameObject;
                
                obj.transform.position = Selection.activeTransform.position + new Vector3(j * 4f, 0, 5 + i * 2);
                ParentNode = Selection.activeTransform.GetComponent<StoryNode>();
                ChildNode = obj.GetComponent<StoryNode>();


                if (ParentNode.Option1 == null)
                {
                    ParentNode.Option1 = ChildNode;
                }
                else if (ParentNode.Option2 == null)
                {
                    ParentNode.Option2 = ChildNode;
                }
                else if (ParentNode.Option3 == null)
                {
                    ParentNode.Option3 = ChildNode;
                }
                else if (ParentNode.Option4 == null)
                {
                    ParentNode.Option4 = ChildNode;
                }
                else if (ParentNode.Option5 == null)
                {
                    ParentNode.Option5 = ChildNode;
                }
                Undo.RegisterCreatedObjectUndo(obj, "Create Linked Nodes");
            }
            else
            {
                Debug.LogError("FAIL LULW");
            }
            j++;
        }
        

    }

}
