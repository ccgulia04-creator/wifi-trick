using UnityEngine;

namespace ApexRush.Multiplayer
{
    public class NetworkRaceManager : MonoBehaviour
    {
        public int maxPlayers = 12;
        public float preRaceCountdown = 5f;

        public void HostLobby()
        {
            Debug.Log("Hosting lobby (stub). Integrate NGO/Photon transport here.");
        }

        public void JoinLobby(string code)
        {
            Debug.Log($"Joining lobby with code {code} (stub).");
        }

        public void StartRace()
        {
            Debug.Log("Race started. Sync race state across clients.");
        }
    }
}
