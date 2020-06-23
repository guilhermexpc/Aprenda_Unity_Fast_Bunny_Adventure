using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private PlayerController _PlayerController;

    [Header("Player")]
    public float velocidadeMovimento;
    [Header("Player Limite Movimentacao")]
    public float limiteXMin;
    public float limiteXMax;
    public float limiteYMin;
    public float limiteYMax;

    [Header("Config Objetos")]
    public GameObject[] gbCenarioPrefab;

    public float velocidadePonte;
    public float objetoDistanciaDestruir;
    public float tamanhoPonte;

    [Header("Globals")]
    public float score;
    public float posXPlayer;

    [Header("UI")]
    public Text txtScore;

    [Header("SFX")]
    public AudioSource fxSource;
    public AudioClip fxPontos;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        txtScore.text = "Score " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        posXPlayer = _PlayerController.transform.position.x;
    }

    public void InstanciarPonte()
    {

    }

    public void Pontuar(int qtdPontos)
    {
        score += qtdPontos;
        txtScore.text = "Score " + score;
        fxSource.PlayOneShot(fxPontos);       
    }

    public void MudarCena(string cenaDestino)
    {
        SceneManager.LoadScene(cenaDestino);
    }
}
