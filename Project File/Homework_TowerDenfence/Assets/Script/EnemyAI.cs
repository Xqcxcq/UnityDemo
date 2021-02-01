using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    private float moveSpeed = 10;
    Transform target;
    private int pointIndex = 0;
	void Start () {
        target = PathPoints.pathPoints[pointIndex];
	}
	
	
	void Update () {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        if(Vector3.Distance(target.position, transform.position) < 0.2f)
        {
            pointIndex++;
            //到达终点
            if(pointIndex >= PathPoints.pathPoints.Length)
            {
                PathEnd();
                return;
            }
            target = PathPoints.pathPoints[pointIndex];
        }
	}
    private void PathEnd()
    {
        Application.LoadLevel("Lose");
        EnemySpawner.EnemyAlive--;
        Destroy(gameObject);
    }
}
