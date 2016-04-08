using System;
using UnityEngine;

public class ShipContorller : MonoBehaviour {

    public GameObject ship;

    public float moveSpeed = 100.0f;
    private float speedCoeff = 1.5f;

    public bool isHyper = false;
    public float hyperSpeed = 200;

    private Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z); //y pos disabled cuz we have a 2d game
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            isHyper = true;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            isHyper = false;

        //Debug.DrawRay(ship.transform.position, newPosition - transform.position, Color.red);

        if (transform.position != newPosition)
        {
            rotateShip(newPosition);
            moveShip(newPosition);
        }
    }

    void rotateShip(Vector3 vector)
    {
        ship.transform.rotation = Quaternion.LookRotation(vector - transform.position);
    }

    void moveShip(Vector3 vector)
    {
        float speed;
        if (isHyper) speed = hyperSpeed; else speed = moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, vector, Time.deltaTime * speed * speedCoeff);
    }

}