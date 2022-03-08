using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCheckPoint : MonoBehaviour
{
    public List<PosCP> positions = new List<PosCP>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerID>())
        {
            PlayerID  player = other.GetComponentInParent<PlayerID>();
            PosCP playerinf = new PosCP();
            playerinf.id = player.playerIdNumber;
            playerinf.lap = player.labCount;
            for (int i = 0; i < positions.Count; i++)
            {
                if (positions[i].id == player.playerIdNumber)
                {
                    positions.RemoveAt(i);
                }
            }
            positions.Add(playerinf);
            player.CheckPos(positions);
        }
    }
}

[System.Serializable]
public class PosCP
{
    public int id;
    public int lap;
}
