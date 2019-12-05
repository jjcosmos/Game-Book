using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealth : MonoBehaviour
{
    // Start is called before the first frame update
    int maxHp;
    int currenthp;
    Slider healthslider;
    Image fillimage;

    void Start()
    {
        healthslider = GetComponent<Slider>();
        fillimage = transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        maxHp = RGameManager.instance.MaxPlayerHealth;
        healthslider.maxValue = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        healthslider.value = RGameManager.PlayerHealth;
        fillimage.color = Color.Lerp(Color.red, Color.green,  (float)RGameManager.PlayerHealth/ (float)maxHp);
    }
}
