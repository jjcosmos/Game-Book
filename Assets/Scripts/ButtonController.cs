using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer mySR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode MappedKey;

    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(MappedKey))
        {
            mySR.sprite = pressedImage;
        }
        if (Input.GetKeyUp(MappedKey))
        {
            mySR.sprite = defaultImage;
        }
    }
}
