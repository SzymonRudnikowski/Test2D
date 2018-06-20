using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    //aktualna populacja planety w danej chwili
    public int population = 0;

    public int maxPopulation = 50;

    //Czas oczekiwania do spawnu
    public float spawnCooldown = 3f;

    //czas ktory uplynal od czasu spawnu ostatniej jednostki
    private float secondsFromLastSpawn = 0f;

    //szablon spawnowaneyy jednostki
    public GameObject unitPrefab;

    //Lista jednostek bedacych aktualnie nad ta planeta
    List<GameObject> units;

    private void Start()
    {
        units = new List<GameObject>(maxPopulation);
    }

    private void Update()
    {
        if(population < maxPopulation)
        {
            secondsFromLastSpawn += Time.deltaTime;
            if(secondsFromLastSpawn >= spawnCooldown)
            {
                Spawn();
                secondsFromLastSpawn = 0f;
            }
        }
    }

    //funkcja ktora jest wywoływana co spawnCooldown by zespalnowac jednostke 
    private void Spawn()
    {
        if(unitPrefab != null)
        {
            var unit = Instantiate(unitPrefab) as GameObject;
            units.Add(unit);
            population++;
        }
    }





}
