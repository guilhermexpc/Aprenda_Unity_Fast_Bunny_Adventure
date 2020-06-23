using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePonte : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D ponteRb;

    private bool instanciado;  

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        ponteRb = GetComponent<Rigidbody2D>();
        ponteRb.velocity = new Vector3(_GameController.velocidadePonte, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!instanciado)
        {
            if (transform.position.x <= 0)
            {
                instanciado = true;
                int idPrefab = Random.Range(0, _GameController.gbCenarioPrefab.Length);
                GameObject temp = Instantiate(_GameController.gbCenarioPrefab[idPrefab]);
                temp.transform.position = new Vector3(transform.position.x + _GameController.tamanhoPonte, transform.position.y, 0);
            }
        }

        if (transform.position.x < _GameController.objetoDistanciaDestruir)
        {
            Destroy(this.gameObject);
        }
    }
}
