using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Lives lives;
    Money money;
    public float startSpeed = 10f;
    public float speed;
    public float startHealth = 100f;
    public float health;
    public int worth = 50;

    private Transform target;
    private int wavepointIndex = 0;

    [Header("Unity Stuff")]
    public Image healthBar;
    private bool isDead = false;

    void Awake()
    {
        lives = GameObject.Find("GameMaster").GetComponent<Lives>();
        money = GameObject.Find("GameMaster").GetComponent<Money>();
    }

    void Start()
    {
        target = Waypoints.points[0];
        speed = startSpeed;
        health = startHealth;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * startSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.6f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Die("gotToEnd");
            Destroy(gameObject);
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die("killed");
            Destroy(gameObject);
        }
    }

    void Die(string cause)
    {
        isDead = true;
        if (cause == "gotToEnd")
        {
            lives.lives--;
        }
        if (cause == "killed")
        {
            money.money++;
        }
        return;
    }
}