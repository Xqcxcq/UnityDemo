using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public float range = 5;             //范围
    public string enemyTag = "Enemy";   //通过标签寻找敌人
    public Transform target;            //攻击目标
    public Transform partRotate;        //旋转的炮台
    public float rotSpeed = 10;         //旋转速度
    public Transform bulletPoint;       //子弹的生成位置

    public GameObject bulletPrefab;     //子弹的预制体
    public float bulletRate = 2f;       //发射子弹的速率
    private float countDown = 0;        //发射子弹的倒计时
    void Start () {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
        countDown = 1 / bulletRate;
    }
	
	
	void Update () {
        if (target == null)
        {
            return;
        }
        LockTarget();
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            Shoot();
            countDown = 1 / bulletRate;
        }
    }
    private void Shoot()
    {
        Debug.Log("发射子弹");
        GameObject bulletGo = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet == null)
        {
            bullet = bulletGo.AddComponent<Bullet>();
        }
        bullet.SetTarget(target);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float minDistance = Mathf.Infinity;
        Transform nearestEnemy = null;
        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }
        if(minDistance < range)
        {
            target = nearestEnemy;
            //enemyHp = target.GetComponent<EnemyHealth>();
            //enemyMove = target.GetComponent<EnemyAI>();
        }
        else
        {
            target = null;
        }
    }
    private void LockTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        Quaternion lerpRot = Quaternion.Lerp(partRotate.rotation, rotation, Time.deltaTime * rotSpeed);
        partRotate.rotation = Quaternion.Euler(new Vector3(0, lerpRot.eulerAngles.y, 0));
    }
}
