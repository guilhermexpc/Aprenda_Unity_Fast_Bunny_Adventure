using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBarril : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D barrilRB;
    private bool pontuado;

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        barrilRB = GetComponent<Rigidbody2D>();
        barrilRB.velocity = new Vector2(_GameController.velocidadePonte, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _GameController.objetoDistanciaDestruir)
        {
            Destroy(this.gameObject);
        }
    }

    private void LateUpdate()
    {
        if (!pontuado && transform.position.x < _GameController.posXPlayer)
        {
            pontuado = true;
            _GameController.Pontuar(10);
        }
    }
}
