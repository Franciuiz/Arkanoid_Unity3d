using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarAlvosNoStart : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] listaAlvos;
    public GameObject[] listaEsmeraldas;

    void Start()
    {

        for (float x = -2; x <= 2; x++) 
        {
            for (float y = -1; y <= 2; y++)
            {
                var pos = new Vector3(x, y, 0);

                int sorteiaPreFabs = Random.Range(0, listaAlvos.Length);
                
                Instantiate(listaAlvos[sorteiaPreFabs], pos, Quaternion.identity);
            }
        }

        for (float x = -1.5F; x <= 1.5; x++)
        {
            for (float y = -0.5F; y <= 1.5; y++)
            {
                var pos = new Vector3(x, y, 0);

                int sorteiaPreFabs = Random.Range(0, listaEsmeraldas.Length);

                Instantiate(listaEsmeraldas[sorteiaPreFabs], pos, Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CongelaTudo()
    {
        Time.timeScale = 0;
    }
}
