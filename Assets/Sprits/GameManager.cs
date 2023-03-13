using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Renderer fondo;
    public GameObject columna;
    public List<GameObject> columnas;
    public float velocidad = 2;
    public GameObject piedrap;
    public GameObject piedrag;
    public GameObject Square;
    public List<Tuple<GameObject,GameObject>> obstaculos;
    public bool finJuego = false;
    public bool start = false;
    public GameObject menuInicio;
    public GameObject menuFin;
    public GameObject textContador;
    private int puntuacion = 0;
    private TMP_Text TextMeshContador;
    private string puntuacionText => "PUNTUACION";

    public void AumentarContador()
    {
        puntuacion++;
        TextMeshContador.text = puntuacionText + " " + puntuacion.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        //creo el escenario
        for (int i = 0; i<21; i++){
            columnas.Add(Instantiate(columna, new Vector2(-10 + i,-3), Quaternion.identity));
        }
        //Iniciamos contador
        TextMeshContador = textContador.GetComponent<TMP_Text>();
        TextMeshContador.text = puntuacionText + " " + puntuacion.ToString();

        //inserto piedras
        obstaculos = new List<Tuple<GameObject, GameObject>>();
        obstaculos.Add(new Tuple<GameObject,GameObject>(Instantiate(Square, new Vector2(10,-1), Quaternion.identity),Instantiate(piedrag, new Vector2(10,-2), Quaternion.identity)));
        obstaculos.Add(new Tuple<GameObject,GameObject>(Instantiate(Square, new Vector2(16,-1), Quaternion.identity),Instantiate(piedrap, new Vector2(16,-2), Quaternion.identity)));

    }



    // Update is called once per frame
    void Update()
    {
        if (start == false){
            if  (Input.GetKeyDown(KeyCode.Space)){
                start = true;
            }
        }

         if (start == true && finJuego ==true){

            menuFin.SetActive(true);
            if  (Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // cuando empiezo el juego
        if (start == true && finJuego == false){
            menuInicio.SetActive(false);


            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
            
        //muevo el escenario
            for (int i = 0; i<columnas.Count; i++){

                if(columnas[i].transform.position.x <= -10){
                    columnas[i].transform.position = new Vector3(10,-3,0);
                }
                columnas[i].transform.position = columnas[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
            }

        //mover las piedras
            for (int i = 0; i<obstaculos.Count; i++){
                var obstaculo = obstaculos[i];
                if(obstaculo.Item1.transform.position.x <= -10){
                    float obstaculo_random = UnityEngine.Random.Range(11,18);
                    obstaculo.Item1.transform.position = new Vector3(obstaculo_random, -1, 0);
                    obstaculo.Item2.transform.position = new Vector3(obstaculo_random, -2, 0);
                }
                obstaculo.Item1.transform.position = obstaculo.Item1.transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
                obstaculo.Item2.transform.position = obstaculo.Item2.transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
            } 
        }

    }
}
