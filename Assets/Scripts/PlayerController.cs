using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D rbPlayer;
    private Vector2 vt2ForcaPulo;

    [Header("Atributos")]
    public float forcaPulo;

    public Transform tfGroundCheck;
    private bool grounded;

    public Vector3 vt3LimiteMovimentacao;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        vt2ForcaPulo = new Vector2(0, forcaPulo);
    }

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
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

        if(Input.GetKeyDown(KeyCode.DownArrow) && !grounded)
        {
            rbPlayer.AddForce(-vt2ForcaPulo * 2);
        }

        //float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //float moveVertical = Input.GetAxisRaw("Vertical");

        //rbPlayer.velocity = new Vector2(moveHorizontal * _GameController.velocidadeMovimento, rbPlayer.velocity.y * _GameController.velocidadeMovimento);
        //LimitarMovimento(transform.position.x, transform.position.y);
    }
    //private void LimitarMovimento(float posicaoX, float posicaoY)
    //{
    //    vt3LimiteMovimentacao = new Vector3(Mathf.Clamp(posicaoX, _GameController.limiteXMin, _GameController.limiteXMax),
    //                                    Mathf.Clamp(posicaoY, _GameController.limiteYMin, _GameController.limiteYMax), 0);
    //    transform.position = vt3LimiteMovimentacao;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        switch (tag)
        {
            case "coletavel":
                {
                    _GameController.Pontuar(10);
                    Destroy(collision.gameObject);
                    break;
                }

            case "obstaculo":
                {
                    _GameController.MudarCena("Scene_Gameover");
                    break;
                }
            default:
                break;
        }
        
    }
}
