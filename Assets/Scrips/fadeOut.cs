using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour
{
    private fade fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType(typeof(fade)) as fade;
        fade.fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
