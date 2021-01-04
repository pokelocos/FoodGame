using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : Component
{
    public float force;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = this.transform.root.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (Active)
        {
            rb.AddForceAtPosition(this.transform.up * force * Time.deltaTime, this.transform.position, ForceMode2D.Force);
        }
    }

    protected override void OnActive()
    {
        sr.color = Color.red;
    }

    protected override void OnDesactive()
    {
        sr.color = Color.white;
    }
}
