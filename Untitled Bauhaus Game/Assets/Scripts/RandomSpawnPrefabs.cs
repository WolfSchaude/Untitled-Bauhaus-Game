using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPrefabs : MonoBehaviour
{
	public Transform[] teleport;
	public GameObject[] prefab;
	public GameObject parent;

	public int prefabCount;

	void Start()
    {
		Spawn();
	}

    void Update()
    {
		 
    }
	public void Spawn()
	{
		for (int i = 0; i < prefabCount; i++)
		{
			int spawnPointX = Random.Range(-300, 300);
			int spawnPointZ = Random.Range(-150, 360);

			Vector3 spawnPosition = new Vector3(spawnPointX, 0.5f, spawnPointZ);

			int tele_num = Random.Range(0, 8);
			int prefeb_num = Random.Range(0, 3);

			Instantiate(prefab[prefeb_num], spawnPosition, Quaternion.identity, parent.transform);
		}
	}
}
