using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public Transform spawnPoint;

    private void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        GameObject prefab = Resources.Load<GameObject>("Character");
        Debug.Log("SpawnCharacter()");
        Debug.Log("PhotonNetwork.IsConnected : " + PhotonNetwork.IsConnected);
        if (PhotonNetwork.IsConnected)
        {
            int idx = PhotonNetwork.LocalPlayer.ActorNumber;
            Vector3 spawnPosition = spawnPoint.position + new Vector3(idx * 2, 0, 0);
            PhotonNetwork.Instantiate(prefab.name, spawnPosition, spawnPoint.rotation);
            //PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, spawnPoint.rotation);
        }
        else
        {
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            //Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
