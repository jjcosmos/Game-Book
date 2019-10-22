using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public StoryNode currentNode;
    [SerializeField] TextMeshProUGUI DisplayText;
    public static TextMeshProUGUI StaticDisplayText;
    void Start()
    {
        if(currentNode != null)
        {
            currentNode.Activate();
        }
        else
        {
            Debug.LogError("Starting story node cannot be unassigned");
        }
    }
    private void Awake()
    {
        StaticDisplayText = DisplayText;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentNode == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentNode.SelectOption(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentNode.SelectOption(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentNode.SelectOption(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentNode.SelectOption(4);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            currentNode.MoveNext();
        }

        if(currentNode.next != null)
        {
            currentNode = currentNode.next;
            currentNode.Activate();
        }
    }
}
