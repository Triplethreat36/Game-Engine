using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Destroy(gameObject, 10f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward * m_Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
} 
