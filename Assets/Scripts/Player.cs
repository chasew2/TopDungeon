using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
private BoxCollider2D boxCollider;
private Vector3 moveDelta;
private RaycastHit2D hit;
private void Start()
{
    boxCollider = GetComponent<BoxCollider2D>();
}

private void FixedUpdate()
{
    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical"); 
    
    //Reset MoveDelta
    moveDelta = new Vector3(x,y,0);

    //Swap sprite dir, right or left
    if (moveDelta.x > 0)
        transform.localScale = Vector3.one;
    else if (moveDelta.x < 0)
        transform.localScale = new Vector3(-1,1,1);

    //Check move direction by casting box there first if returns null we can move
    hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
    if (hit.collider == null)
    {
       //Move
    transform.Translate(0, moveDelta.y * Time.deltaTime, 0); 
    }
    hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
    if (hit.collider == null)
    {
       //Move
    transform.Translate(moveDelta.x * Time.deltaTime, 0, 0); 
    }
}
}
