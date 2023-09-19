using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AppleTree : MonoBehaviour
{


    [Header("Set in Inspector")]

    public GameObject applePrefab;
    public float      speed = 1f;
    public float      leftAndRightEdge = 10f;
    public float      chanceToChangeDirections = 0.1f;
    public float      secondsBetweenAppleDrops = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
        // Dropping apples every second

    }

    // Update is called once per frame
    void Update()
    {

        //tree movement

        Vector3 pos = transform.position;       // current position
        pos.x += speed * Time.deltaTime;        // change in time * speed
        transform.position = pos;               // pos becomes new location of tree

        // changing directions

        if (pos.x < -leftAndRightEdge)
        {
            // are we at the left-most side?
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            // are we at the right-most side?
            speed = -Mathf.Abs(speed);
        }


    }
}
