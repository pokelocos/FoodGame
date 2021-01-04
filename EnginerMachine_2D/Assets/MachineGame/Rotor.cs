using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : Component
{
    public float speedRot;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    protected override void OnActive()
    {
        sr.color = Color.green;
    }


    protected override void OnDesactive()
    {
        sr.color = new Color(233f/255f, 200f/255f, 133f/255f, 255f/255f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            // some
        }
    }

    private void FixedUpdate()
    {
        if (Active)
            this.transform.Rotate(0, 0, speedRot * Time.deltaTime);
    }

    private void LateUpdate()
    {
        //if (Active)
        //    this.transform.Rotate(0, 0, speedRot * Time.deltaTime);
    }
}
