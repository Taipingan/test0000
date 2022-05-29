using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenContrllerScript : MonoBehaviour
{       
    public float speed;
    public float pX;
    public float pY;
    public float pZ;
    public Animator AnimatorScript;
    public bool isFence;
    public bool isShock;
    public bool isChicken;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        isFence = false;
        isShock = false;
        isChicken = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        fixPosition();
        float Distanciing = ToPlayerDistanciing();
        if (Distanciing <= 3)
        {
            // turnRight();
            //run();
            //this.transform.lookAt(player.transform * -1);
            this.transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
            run();
            fixLocation();
        }
        else
        {
            if (isFence == true)
            {
                idle();
                // this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.3F);
                turnRight();
                isFence = false;
            }
            else if (isShock == true)
            {
                Shocked();
                isShock = false;
            }
            else if (isChicken == true)
            {
                idle();
                tureAround();
                isChicken = false;
            }
            else
            {
                fixLocation();
                fixPosition();
                walk();
            }
        }
    }
    void walk()
    {
        speed = 0.01F;
        pX = this.transform.position.x;
        pY = this.transform.position.y;
        pZ = this.transform.position.z;
        /* Debug.Log("pX = " + pX);
         Debug.Log("pY = " + pY);
         Debug.Log("pZ = " + pZ);
         pZ = pZ + speed;
         this.transform.position = new Vector3(pX, pY, pZ);*/
        this.transform.Translate(new Vector3(0, 0, speed));
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Walk In Place");
        }
    }

    void run()
    {
        speed = 0.02F;
        pX = this.transform.position.x;
        pY = this.transform.position.y;
        pZ = this.transform.position.z;
        /*Debug.Log("pX = " + pX);
        Debug.Log("pY = " + pY);
        Debug.Log("pZ = " + pZ);
        pZ = pZ + speed;
        this.transform.position = new Vector3(pX, pY, pZ);*/
        this.transform.Translate(new Vector3(0, 0, speed));
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Run In Place");
        }
    }
    void sprun()
    {
        speed = 0.1F;
        pX = this.transform.position.x;
        pY = this.transform.position.y;
        pZ = this.transform.position.z;
        /* Debug.Log("pX = " + pX);
         Debug.Log("pY = " + pY);
         Debug.Log("pZ = " + pZ);
         pZ = pZ + speed;
         this.transform.position = new Vector3(pX, pY, pZ);*/
        this.transform.Translate(new Vector3(0, 0, speed));
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Run In Place");
        }
    }
    void idle()
    {
        AnimatorScript = this.GetComponent<Animator>();
        if (AnimatorScript != null)
        {
            AnimatorScript.Play("Idle");
        }
    }
    void fixPosition()
    {
        //  float leftZ = 3;
        //   float RightZ = 7;
        // float frontX = -18;
        // float backX = -29;
        if (this.transform.position.z >= 3.3)
        {
            this.transform.position = new Vector3((float)-24.09, (float)-0.06549445, (float)2.4);
        }
        else if (this.transform.position.z <= -8.704)
        {
            this.transform.position = new Vector3((float)-24.09, (float)-0.06549445, (float)-6.61);
        }
        else if (this.transform.position.x >= -18.184)
        {
            this.transform.position = new Vector3((float)-19.43, (float)-0.06549445, (float)-2.48);
        }
        else if (this.transform.position.x <= -30.61)
        {
            this.transform.position = new Vector3((float)-29.058, (float)-0.06549445, (float)-2.48);
        }
    }
    void fixLocation()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
    void OnConllisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name + "Crash");

    }
    void OnTriggerEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag + " Crash " + collision.collider.name);
        if (collision.collider.tag == "Fence")
        {
            isFence = true;
        }
        else if (collision.collider.tag == "Player")
        {
            isShock = true;
        }
        else if (collision.collider.tag == "Chicken")
        {
            isChicken = true;
        }
        else
        {
            isFence = false;
            isShock = false;
        }
    }
    float ToPlayerDistanciing()
    {
        Vector3 thistank;
        thistank = this.transform.position - player.transform.position;
        //Debug.Log(thistank.magnitude);
        return thistank.magnitude;
    }
    void turnRight()
    {
        float Yeuler;
        float yRotation = 90.0f;
        Yeuler = this.transform.eulerAngles.y;
        yRotation = Yeuler + Random.Range(100, 180);
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        transform.eulerAngles = new Vector3(0, yRotation, 0);
    }
    void tureLeft()
    {

    }
    void tureAround()
    {
        float Yeuler;
        float yRotation = 90.0f;
        Yeuler = this.transform.eulerAngles.y;
        yRotation = Yeuler + Random.Range(0, 360);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
    }
    void Shocked()
    {
        run();
        delay();
        walk();
    }
    public IEnumerable delay()
    {
        yield return new WaitForSeconds(500);
    }
}
