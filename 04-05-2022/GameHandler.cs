using System.IO;
using System.Collections;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("GameHandler.Start");

        /*
        PlayerData playerData = new PlayerData();
        playerData.position = new Vector3(8, 0);
        playerData.health = 110;

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
        */

        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");

        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log("position: " + loadedPlayerData.position);
        Debug.Log("health: " + loadedPlayerData.health);


    }
    private class PlayerData
        {
            public Vector3 position;
            public int health;
        }









}
