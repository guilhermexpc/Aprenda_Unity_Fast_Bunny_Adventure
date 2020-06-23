using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private Vector2 vt2ForcaPulo;

    [Header("Atributos")]
    public float forcaPulo;

    public Transform tfGroundCheck;
    private bool grounded;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        vt2ForcaPulo = new Vector2(0, forcaPulo);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(tfGroundCheck.position, 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rbPlayer.AddForce(vt2ForcaPulo);
        }
    }
}
