using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D _rb;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        /*transform.position = (Vector3)new Vector2(2, 1);
        Invoke(nameof(AcceptDefeat), 300);*/
    }

    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        
        _rb.velocity = new Vector2(xAxis * speed, yAxis * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AcceptDefeat()
    {
        Destroy(gameObject);
    }
}
