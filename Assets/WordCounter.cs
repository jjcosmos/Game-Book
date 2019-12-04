using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class WordCounter : MonoBehaviour
{
    static string Story = "";
    [SerializeField] [TextArea] string visStory;

    [MenuItem("MyTools/WordCount!")]
    static void CountWords()
    {
        List<StoryNode> nodes = GameObject.FindObjectsOfType<StoryNode>().ToList<StoryNode>();
        foreach (var item in nodes)
        {
            foreach (string line in item.Dialogue)
            {
                if(line.Contains("blah"))
                {
                    Debug.Log(item.name, item);
                }
                Story = Story + "\n" + line;
            }

            
        }
        EditorGUIUtility.systemCopyBuffer = Story;
    }
}
