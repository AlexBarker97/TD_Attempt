using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float bulletSpeed;
    public float damage;

    void Start()
    {

        if (gameObject.transform.parent.GetComponent<Turret1>())
        {
            bulletSpeed = gameObject.transform.parent.GetComponent<Turret1>().bulletSpeed;
        }
        if (gameObject.transform.parent.GetComponent<Turret2>())
        {
            bulletSpeed = gameObject.transform.parent.GetComponent<Turret2>().bulletSpeed;
        }
        if (gameObject.transform.parent.GetComponent<Turret3>())
        {
            bulletSpeed = gameObject.transform.parent.GetComponent<Turret3>().bulletSpeed;
        }

        if (gameObject.transform.parent.GetComponent<Turret1>())
        {
            damage = gameObject.transform.parent.GetComponent<Turret1>().damage;
        }
        if (gameObject.transform.parent.GetComponent<Turret2>())
        {
            damage = gameObject.transform.parent.GetComponent<Turret2>().damage;
        }
        if (gameObject.transform.parent.GetComponent<Turret3>())
        {
            damage = gameObject.transform.parent.GetComponent<Turret3>().damage;
        }
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
