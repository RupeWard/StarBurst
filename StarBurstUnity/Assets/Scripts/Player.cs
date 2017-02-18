using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RJWard.StarBurst
{
	public class Player : MonoBehaviour
	{
		public float speed = 1f;

		private void Update()
		{
			if (Input.GetKey(KeyCode.D))
			{
				transform.position += transform.forward * speed * Time.deltaTime;
			}
			/*
			if (Input.GetKey( KeyCode.A ))
			{
				transform.position -= transform.forward * speed * Time.deltaTime;
			}
			*/
		}
	}

}
