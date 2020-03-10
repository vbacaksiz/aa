using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCircleCode : MonoBehaviour
{
    public GameObject smallCircle;
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManagerTag");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            createSmallCircle();
        }
    }

    void createSmallCircle()
    {
        Instantiate(smallCircle, transform.position, transform.rotation);
        gameManager.GetComponent<gameManagement>().smallCircleText();
    }
}
