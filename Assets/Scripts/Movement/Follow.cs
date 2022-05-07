using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Rigidbody2D _self;
    public Rigidbody2D target;

    // Start is called before the first frame update
    void Start()
    {
        _self = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _self.velocity = target.velocity;
    }
}