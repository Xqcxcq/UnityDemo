using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform m_Target;
    public float speed = 80;            //子弹的速度
    public float damage = 50;           //受伤的攻击力
    public float exploseRadius;    //爆炸范围
    public GameObject bulletImpactEffect;
    public void SetTarget(Transform target)
    {
        m_Target = target;
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Target == null)
        {
            Destroy(gameObject);            //这里是为了使得如果前一发魔法弹把恶魔已经打死但是后一发已经出去，那么销毁后一发因为目标已经消失。
            return;
        }
        if (Vector3.Distance(m_Target.position, transform.position) < speed * Time.deltaTime)
        {
            HitTarget();
            return;
        }
        Vector3 dir = m_Target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(m_Target);                                      //这步让魔法弹一直朝向目标去看（万一魔法弹可能不是圆的呢。
    }
    private void HitTarget()
    {
        if (exploseRadius > 0)
        {
            Explose();
        }
        else
        {
            //一般的子弹
            EnemyDamage(m_Target);
        }
        //销毁自己
        Destroy(gameObject);
    }

    private void Explose()
    {
        
        //圆的范围内碰到的所有的collider
        Collider[] colliders = Physics.OverlapSphere(transform.position, exploseRadius);
        foreach (var item in colliders)
        {
            Debug.Log(item.name);
            if (item.tag == "Enemy")
            {
                Debug.Log("爆炸");
                EnemyDamage(item.transform);
            }
        }
    }

    private void EnemyDamage(Transform enemy)
    {
        EnemyHealth enemyHp = enemy.GetComponent<EnemyHealth>();
        if (enemyHp != null)
        {
            enemyHp.Damage(damage);
        }
    }
}
