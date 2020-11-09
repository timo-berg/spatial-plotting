using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAvatars : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] gos;
    public List<string> playerNameList;
    public List<int> trialIndexList;
    public List<Color> avatarColorList;
    public Vector3 centerCoords;
    public Vector3 offsetCoords;
    private IKAvatar ikavatar;

    void Awake()
    {
        centerCoords = new Vector3(0, 0, 0); 

    int nAvatars = playerNameList.Count;
        gos = new GameObject[nAvatars];

    for (int i = 0; i < gos.Length; i++)
        {
            GameObject clone = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
            ikavatar = clone.GetComponent<IKAvatar>();
            ikavatar.playerName = playerNameList[i];
            ikavatar.trialIndex   = trialIndexList[i];
            ikavatar.offsetCoords = i*offsetCoords;
            ikavatar.modelColor = avatarColorList[i];
            gos[i] = clone;
            
        }
        prefab.SetActive(false);
    }
}