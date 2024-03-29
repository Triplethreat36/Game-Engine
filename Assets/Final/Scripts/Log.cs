using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemys
{
    public Transform target;
    public float chaseRaidus;
    public float attackRaidus;
    public Transform homePosition;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) > attackRaidus) 
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position,moveSpeed * Time.deltaTime);
        }
    }
}
