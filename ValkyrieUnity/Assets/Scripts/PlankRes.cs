//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

/*This code works best with WHITE color because it does vector multiplication.
Won't work with BLACK sprites because black's vector value is (0,0,0), thus,anything multiplied 0 is 0
Best is to import WHITE sprites and then set the colour here of the sprite*/

public class PlankRes : MonoBehaviour {

	public Color altColor; //We can manually pick the colour

	void OnCollisionEnter2D(Collision2D col){
		this.gameObject.GetComponent<SpriteRenderer>().color=altColor;
	}

}


