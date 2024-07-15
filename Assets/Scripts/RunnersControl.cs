using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnersControl : MonoBehaviour
{

    public GameObject _runner1;
    public GameObject _runner2;
    public GameObject _runner3;
    public GameObject _runner4;
    public GameObject _runner5;
    public GameObject _runner6;
    public GameObject _runner7;
    public GameObject _runner8;
    public GameObject _runner9;
    public GameObject _runner10;
    public float _transferSpace;
    public float _speed;
    
    private GameObject[] runnersArray;
    private int currentRunnerIndex;
    private int nextRunnerIndex;    

    void Start()
    {        
        currentRunnerIndex = 0;
        nextRunnerIndex = currentRunnerIndex + 1;        
        runnersArray = new GameObject[10] { _runner1, _runner2, _runner3, _runner4, _runner5, _runner6, _runner7, _runner8, _runner9, _runner10 };
        runnersArray[currentRunnerIndex].transform.LookAt(runnersArray[nextRunnerIndex].transform);
        runnersArray[nextRunnerIndex].transform.LookAt(runnersArray[currentRunnerIndex].transform);
    }
    
    void Update()
    {        
        if (Vector3.Distance(runnersArray[currentRunnerIndex].transform.position, runnersArray[nextRunnerIndex].transform.position) > _transferSpace)
            runnersArray[currentRunnerIndex].transform.position = Vector3.MoveTowards(runnersArray[currentRunnerIndex].transform.position, runnersArray[nextRunnerIndex].transform.position, Time.deltaTime * _speed);
        else
        {
            currentRunnerIndex = nextRunnerIndex;
            if (currentRunnerIndex == 9)
                nextRunnerIndex = 0;
            else
                nextRunnerIndex++;
            runnersArray[currentRunnerIndex].transform.LookAt(runnersArray[nextRunnerIndex].transform);
            runnersArray[nextRunnerIndex].transform.LookAt(runnersArray[currentRunnerIndex].transform);
        }
        
        transform.position = runnersArray[currentRunnerIndex].transform.position + runnersArray[currentRunnerIndex].transform.TransformDirection(new Vector3 (0.06f, 0, 0.16f));
    }
}
