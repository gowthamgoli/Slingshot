using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdjustVolume : MonoBehaviour {



		public Slider mySlider;

		public void changeVolume ()
		{
			AudioListener.volume = mySlider.value;
		}



}
