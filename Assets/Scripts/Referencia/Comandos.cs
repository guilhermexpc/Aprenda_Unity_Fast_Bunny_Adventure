using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comandos : MonoBehaviour
{
    public void MudarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
