using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Gamemanager gamemanager;
    [SerializeField] float LerpSpeed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.currentNode.CameraFocus.position != transform.position)
        {
            transform.position = Vector3.Slerp(transform.position, gamemanager.currentNode.CameraFocus.position, Time.deltaTime * LerpSpeed);
        }
    }
}
