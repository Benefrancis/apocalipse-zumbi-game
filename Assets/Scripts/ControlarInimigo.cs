using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarInimigo : MonoBehaviour {

    public GameObject Jogador;
    public float Velocidade = 5;

	// Use this for initialization
	void Start () {
        Jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;
        Quaternion novaRoracao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRoracao);

        if (distancia > 2.5)
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * Velocidade * Time.deltaTime);
            GetComponent<Animator>().SetBool("Atacando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", true);
        }

    }

    void AtacaJogador()
    {
        Time.timeScale = 0;
        Jogador.GetComponent<ControlarJogador>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<ControlarJogador>().Vivo = false;
       // Jogador.GetComponent<ControlarJogador>().TextoGameOver.transform.position = Jogador.transform.position;



    }

}
