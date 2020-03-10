using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallCircleCode : MonoBehaviour
{
    Rigidbody2D physics;
    public float speed;
    bool movementControl = false;
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("gameManagerTag");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!movementControl)
        {
            physics.MovePosition(physics.position + Vector2.up * speed * Time.deltaTime);

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="rotatingCircleTag")
        {
            transform.SetParent(col.transform);
            movementControl = true;
        }
        if(col.tag=="smallCircleTag")
        {
            gameManager.GetComponent<gameManagement>().gameOver();
        }
    }
}
