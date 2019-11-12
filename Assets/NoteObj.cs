using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObj : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canBePressed;
    public KeyCode keyToPress;
    private bool Cleared;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                

                RGameManager.instance.NoteHit();
                Cleared = true;
                gameObject.SetActive(false);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            canBePressed = false;
            if (!Cleared)
            {
                RGameManager.instance.NoteMissed();
            }
        }
    }
}
