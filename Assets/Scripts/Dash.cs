using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    private float dashHorizontalDirection;
    Rigidbody playerBody;
    bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dashHorizontalDirection = Player.horizontalInput;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isDashing = true;
            Debug.Log("DASH BUTTON");
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            Dashing();
        }
    }

    private void Dashing()
    {
        //playerBody.AddForce(transform.right * dashSpeed, ForceMode.Impulse);
        playerBody.velocity = new Vector3(dashHorizontalDirection * dashSpeed, playerBody.velocity.y, 0);
        Debug.Log("FORCE APPLIED");
        isDashing = false;
    }
}
