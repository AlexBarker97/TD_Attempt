using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Lives lives;

    public float startSpeed = 10f;
    public float speed;
    public float startHealth = 100f;
    public float health;
    public int worth = 50;

    private Transform target;
    private int wavepointIndex = 0;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Awake()
    {
        lives = GameObject.Find("GameMaster").GetComponent<Lives>();
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

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        health = health - 0.006f;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die("health <= 0");
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Die("gotToEnd");
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void Die(string cause)
    {
        Destroy(gameObject);
        if (cause == "gotToEnd")
        {
            lives.lives--;
        }
    }

}
