using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallFly : MonoBehaviour
{
    public float moveSpeed;
    Vector2[] forward= { Vector2.up,new Vector2(1,1),Vector2.right,new Vector2(1,-1),Vector2.down,new Vector2(-1,-1),Vector2.left,new Vector2(-1,1)};
    public float timescale;
    public float ballToHoopDistance;

    float time;
    int r;
    Rigidbody2D magicBallRig;
    
    // Start is called before the first frame update
    void Start()
    {
        magicBallRig = this.GetComponent<Rigidbody2D>();
        time = Time.time;
        magicBallRig.gravityScale = 0;
        r = Random.Range(0, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (magicBallRig.gravityScale==0)
        {
            if (Time.time - time >= timescale)
            {
                r = Random.Range(0, 7);
                time = Time.time;
                //DebugPrint(r);
            }
            magicBallRig.velocity = forward[r] * moveSpeed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tag = collision.collider.tag;
        switch (tag)
        {
            case "land":
                if (magicBallRig.gravityScale != 0)
                    break;
                if (collision.transform.position.y - this.transform.position.y > 0)
                {
                    if (collision.transform.position.x - this.transform.position.x > 0)
                    {
                        r = 5;
                    }
                    else if(collision.transform.position.x - this.transform.position.x == 0)
                    {
                        r = 4;
                    }
                    else
                    {
                        r = 3;
                    }
                }
                else if(collision.transform.position.y - this.transform.position.y < 0)
                {
                    if (collision.transform.position.x - this.transform.position.x > 0)
                    {
                        r = 7;
                    }
                    else if (collision.transform.position.x - this.transform.position.x == 0)
                    {
                        r = 0;
                    }
                    else
                    {
                        r = 1;
                    }
                }
                else
                {
                    if (collision.transform.position.x - this.transform.position.x > 0)
                    {
                        r = 5;
                    }
                    else
                    {
                        r = 1;
                    }
                }
                break;
            case "button":
                magicBallRig.gravityScale = 1;
                break;
            case "targetHoop":
                if (magicBallRig.gravityScale != 0 && this.transform.position.y - collision.transform.position.y >= ballToHoopDistance)
                {
                    ScoreManager.singleton.WeScore();
                }
                break;
            case "ownHoop":
                if (magicBallRig.gravityScale != 0 && this.transform.position.y - collision.transform.position.y >= ballToHoopDistance)
                {
                    ScoreManager.singleton.OpponentScore();
                }
                break;
        }
    }
    void DebugPrint(int r)
    {
        switch (r)
        {
            case 0:
                Debug.Log("⬆");
                break;
            case 1:
                Debug.Log("↗");
                break;
            case 2:
                Debug.Log("→");
                break;
            case 3:
                Debug.Log("↘");
                break;
            case 4:
                Debug.Log("↓");
                break;
            case 5:
                Debug.Log("↙");
                break;
            case 6:
                Debug.Log("←");
                break;
            case 7:
                Debug.Log("↖");
                break;
        }
    }
}
