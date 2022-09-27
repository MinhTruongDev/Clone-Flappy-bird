using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 1f;
    [SerializeField]
    float backgroundCount = 2f;
    [SerializeField]  
    float backgroundWidth;
   

    // Update is called once per frame
    void Update()
    {        
        Scroller();
    } 


    private void Scroller()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        Vector3 pos = transform.position;
        if (pos.x < -backgroundWidth)
        {
            pos.x += backgroundCount * backgroundWidth;
            transform.position = pos;
        }
    }
}
