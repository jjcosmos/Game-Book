using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
[ExecuteInEditMode]
public class SentenceSplitter : MonoBehaviour
{
    [SerializeField] [TextArea]string Fulltext;
    [SerializeField] StoryNode nodeToInputTo;
    private List<string> output;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        string[] output = Fulltext.Split('.');
        List<string> SOutput = output.ToList<string>();
        nodeToInputTo.Dialogue = SOutput;
    }

    private void Update()
    {
        
        string[] output = Fulltext.Split('.');
        List<string> SOutput = output.ToList<string>();
        nodeToInputTo.Dialogue = SOutput;
        
    }
}
