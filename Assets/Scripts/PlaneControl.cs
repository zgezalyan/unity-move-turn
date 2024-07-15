using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlaneControl : MonoBehaviour
{
    public int _numberOfPoints;
    public int _speed;

    private Vector3[] pointsArray;
    private Vector3 currentDestination;
    private int currentDestinationIndex;
    private bool isForward;

    public void Start()
    {        
        GeneratePointArray();
        isForward = true;
        SetNextDestination(0);
        transform.LookAt(currentDestination); 
    }

    
    public void Update()
    {
        if (transform.position != currentDestination)
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, Time.deltaTime * _speed);
        else
        {
            if (isForward)
            {
                if (currentDestinationIndex < _numberOfPoints - 1)
                    SetNextDestination(currentDestinationIndex + 1);
                else
                {
                    SetNextDestination(currentDestinationIndex - 1);
                    isForward = false;
                }
            }
            else
            {
                if (currentDestinationIndex > 0)
                    SetNextDestination(currentDestinationIndex - 1);
                else
                {
                    SetNextDestination(currentDestinationIndex + 1);
                    isForward = true;
                }
            }
            transform.LookAt(currentDestination);
        }
        transform.Rotate(0, 0, 2);
    }

    public void GeneratePointArray()
    {
        pointsArray = new Vector3[_numberOfPoints];
        Random rnd = new Random();

        for (int i = 0; i < _numberOfPoints; i++)
        {
            float newX = rnd.Next(-1001, 1001) * 0.01f;
            float newY = rnd.Next(100, 701) * 0.01f;
            float newZ = rnd.Next(-1001, 1001) * 0.01f;

            pointsArray[i].Set(newX, newY, newZ);
        }        
    }

    public void SetNextDestination(int index)
    {
        currentDestinationIndex = index;
        currentDestination = pointsArray[currentDestinationIndex];
    }
}
