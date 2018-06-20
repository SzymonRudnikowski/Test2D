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
            Instantiate(unitPrefab);
            population++;
        }
    }





}
