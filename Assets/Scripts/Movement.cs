using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashSpeed;    
    [SerializeField] private LineRenderer lineRenderer;
    private Rigidbody rb;
    private bool canDash;
    private bool dashing;
    public float time;


    // Start is called before the first frame update
    void Start()
    {
        dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(transform.right * walkingSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);

        }

        if (Input.GetAxis("Vertical") != 0)
        {
            
            transform.Translate(transform.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {

            RaycastHit result;
            bool thereWasHit = Physics.Raycast(transform.position, transform.forward, out result, Mathf.Infinity);

            // ------- The straight line trajectory code -------//
            Vector3 start = transform.position;
            Vector3 end = transform.position + transform.forward * 50f;
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);

            if (thereWasHit)
            {
                result.collider.gameObject.GetComponent<MeshRenderer>().material.color = GetRandomColor();
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && dashing == false)
        {
            
            DashTrigger();
            
        }

        if (canDash)
        {
            DashCount();
        }
    }

    private Color GetRandomColor()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        return color;
    }

    private void DashTrigger()
    {
        canDash = true;

       if(Input.GetAxis("Vertical")!= 0)
        {
            DashVertical();
        }

       if(Input.GetAxis("Horizontal") != 0)
        {
            DashHorizontal();
        }

        if (canDash)
        {
            dashing = true;
        }
        
    }

    private void DashCount()
    {
        
      
        time += Time.deltaTime;
        if(time >= 2f)
        {
            canDash = false;
            dashing = false;
            time = 0;
        }
             

    }

    private void DashVertical()
    {
        transform.Translate(transform.forward * dashDistance * dashSpeed * Input.GetAxis("Vertical"), Space.World); // Replace both for Addforce also makes jump same way
    }

    private void DashHorizontal()
    {
        transform.Translate(transform.right * dashDistance * dashSpeed * Input.GetAxis("Horizontal"), Space.World);
    }
}
