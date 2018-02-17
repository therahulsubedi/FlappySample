using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMaker : MonoBehaviour
{
    public GameObject obstacle, ground;

    public float distanceBetweenTwoObstacles;
    public float previousObstacelXPosition;
    Queue<GameObject> ObstaclesQ = new Queue<GameObject>();
    Queue<GameObject> groundQ = new Queue<GameObject>();
    public static CloneMaker MyObject;

    // Use this for initialization
    void Start()
    {
        MyObject = this;
        for (int i = 0; i < 4; i++)
        {
            Vector2 newpos = new Vector2(previousObstacelXPosition, Random.Range(-3.07f, 3.5f));
            Vector2 newGroundPos = new Vector2(previousObstacelXPosition - 3, -8.88f);
            GameObject obsClone = Instantiate(obstacle, newpos, Quaternion.identity);
            ObstaclesQ.Enqueue(obsClone);
            GameObject groundClone = Instantiate(ground, newGroundPos, Quaternion.identity);
            groundQ.Enqueue(groundClone);
            //end of loop

            previousObstacelXPosition += distanceBetweenTwoObstacles;
        }
    }

    public void ReuseMe()
    {
        Vector2 newpos = new Vector2(previousObstacelXPosition, Random.Range(-3.07f, 3.5f));
        Vector2 newGroundPos = new Vector2(previousObstacelXPosition - 3, -8.88f);
        GameObject newObs = ObstaclesQ.Dequeue();
        newObs.transform.position = newpos;
        ObstaclesQ.Enqueue(newObs);
        GameObject newGround = groundQ.Dequeue();
        newGround.transform.position = newGroundPos;
        groundQ.Enqueue(newGround);
        //end of function
        previousObstacelXPosition += distanceBetweenTwoObstacles;
    }
}