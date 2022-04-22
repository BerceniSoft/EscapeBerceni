using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            GameObject.FindGameObjectWithTag(Tags.DIALOG_BOX_TAG).GetComponent<DialogBox>().ShowDialog("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","Eminescu");
        }
    }
}
