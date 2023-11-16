using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float bulletSpeed;
    public float damage;

    void Start()
    {
        bulletSpeed = this.transform.parent.gameObject.GetComponent<Turret1>().bulletSpeed;
        damage = this.transform.parent.gameObject.GetComponent<Turret1>().damage;
    }
    
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget ()
    {
        Damage(target);
        Destroy(gameObject);
        return;
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
}
