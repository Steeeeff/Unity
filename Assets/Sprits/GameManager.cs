using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Renderer fondo;
    public GameObject columna;
    public List<GameObject> columnas;
    public float velocidad = 2;
    public GameObject piedrap;
    public GameObject piedrag;
    public List<GameObject> obstaculos;
    public bool finJuego = false;
    public bool start = false;
    public GameObject menuInicio;
    public GameObject menuFin;
    // Start is called before the first frame update
    void Start()
    {
        //creo el escenario
        for (int i = 0; i<21; i++){
            columnas.Add(Instantiate(columna, new Vector2(-10 + i,-3), Quaternion.identity));
        }

        //inserto piedras
        obstaculos.Add(Instantiate(piedrap, new Vector2(10,-2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedrag, new Vector2(16,-2), Quaternion.identity));


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

                if(obstaculos[i].transform.position.x <= -10){
                    float obstaculo_random = Random.Range(11,18);
                    obstaculos[i].transform.position = new Vector3(obstaculo_random, -2, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
            } 
        }

    }
}
