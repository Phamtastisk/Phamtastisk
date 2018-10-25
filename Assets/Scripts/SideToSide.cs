using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour
{

    [Range(0, 150)] public float max; //how much we want the platform to move, I clamped it to 0,1 to make sure it wouldn't move too far
    public float speed;
    public bool moves = false;
    private GameObject target = null;
    private Vector3 Offset;

    bool movingRight = true;
    Vector2 originPosition;

    // Use this for initialization
    void Start()
    {
        //save original position
        originPosition = transform.position;

        //do a toin coss to decide if it is a moving platform or not
        if (Random.Range(0, 2) == 1)
            moves = true;

        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        //if it is a moving platform
        if (moves)
        {
            if (movingRight)
            {
                //move the platform to the right
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                //if it moved past the defined threshold, then move to the left 
                if (transform.position.x > originPosition.x + max)
                {
                    movingRight = false;
                }
            }
            else //as above, but when the platform is moving left
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                if (transform.position.x < originPosition.x)
                {
                    movingRight = true;
                }
            }
        }
        if (target != null)
        {
            target.transform.position = transform.position + Offset;
        }
    }


    void OnTriggerStay2D(Collider2D move) {
        target = move.gameObject;
        Offset = target.transform.position - transform.position;
        }

    void OnTriggerExit2D(Collider2D moveV2) {
        target = null;
    }
}
