using TMPro;
using UnityEngine;

namespace ApexRush.UI
{
    public class HUDController : MonoBehaviour
    {
        public ApexRush.Core.CarController playerCar;
        public TextMeshProUGUI speedText;
        public TextMeshProUGUI lapText;
        public TextMeshProUGUI positionText;
        public GameObject wrongWayIndicator;

        private int _lap = 1;
        private int _position = 1;

        private void Update()
        {
            if (playerCar != null && speedText != null)
            {
                speedText.text = $"{Mathf.RoundToInt(playerCar.SpeedKph)} km/h";
            }

            if (lapText != null) lapText.text = $"Lap {_lap}/3";
            if (positionText != null) positionText.text = $"P{_position}";
        }

        public void SetRaceState(int lap, int position, bool wrongWay)
        {
            _lap = lap;
            _position = position;
            if (wrongWayIndicator != null)
            {
                wrongWayIndicator.SetActive(wrongWay);
            }
        }
    }
}
