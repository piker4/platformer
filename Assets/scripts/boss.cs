using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject player;
    public bool toggle = true;
    public Rigidbody2D rb2d;
    public float pushforce = 500f;

    public GameObject rock;

    public int counter = 0;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(2 <= Mathf.Abs(transform.position.x - player.transform.position.x) && Mathf.Abs(transform.position.x - player.transform.position.x) <= 7 && toggle == true && counter <=3)
        {
            StartCoroutine(Attack());
        } 
        if(2 <= Mathf.Abs(transform.position.x - player.transform.position.x) && Mathf.Abs(transform.position.x) <= 7 && toggle == true && counter <=7)
        {
           GameObject rockclone = Instantiate(rock, new Vector3(transform.position.x + 2, transform.position.y +5, transform.position.z), transform.rotation);
        } 
    }

    IEnumerator Attack()
    {
        toggle = false;
        print("Заряд");
        yield return new WaitForSeconds(3.0f);
        if(transform.position.x - player.transform.position.x > 0)
        {
            rb2d.AddForce(transform.right * pushforce * -1);
        }
        else
        {
            rb2d.AddForce(transform.right * pushforce);
        }
        yield return new WaitForSeconds(2.0f);
        toggle = true;
        counter ++;
    }
}
