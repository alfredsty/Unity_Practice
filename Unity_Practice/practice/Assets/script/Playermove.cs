using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float maxspeed;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }    
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxspeed) // right max speed
            rigid.velocity = new Vector2(maxspeed,rigid.velocity.y);
         else if (rigid.velocity.x < maxspeed*(-1)) //left max speed
            rigid.velocity = new Vector2(maxspeed*(-1), rigid.velocity.y);


    }

}
