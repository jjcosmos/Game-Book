using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;

public class WordCounter : MonoBehaviour
{
    static string Story = "";
    [SerializeField] [TextArea] string visStory;

    [MenuItem("MyTools/WordCount!")]
    static void CountWords()
    {
        string docPath = "Assets/Resources/Transcript.txt";
        StreamWriter writer = new StreamWriter(docPath, true);
        List<StoryNode> nodes = GameObject.FindObjectsOfType<StoryNode>().ToList<StoryNode>();
        foreach (var item in nodes)
        {
            foreach (string line in item.Dialogue)
            {
                if(line.Contains("blah"))
                {
                    Debug.Log(item.name, item);
                }
                writer.WriteLine(line);
                //Story = Story + "\n" + line;
            }

            
        }
        writer.Close();
        EditorGUIUtility.systemCopyBuffer = Story;
    }
}
