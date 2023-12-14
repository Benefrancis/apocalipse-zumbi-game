using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarCamera : MonoBehaviour {


    public GameObject Jogador;
    Vector3 distanciaCompensar;

	// Use this for initialization
	void Start () {
        distanciaCompensar = transform.position - Jogador.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Jogador.transform.position + distanciaCompensar;
	}
}
