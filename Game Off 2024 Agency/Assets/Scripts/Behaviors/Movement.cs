using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float changeDirectionTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(changeDirection());
        Physics2D.IgnoreLayerCollision(3,3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(moveSpeed, 0);
    }
    IEnumerator changeDirection(){
        while (true){
            yield return new WaitForSeconds(changeDirectionTime);
            moveSpeed = -moveSpeed;
        }
    }
}
