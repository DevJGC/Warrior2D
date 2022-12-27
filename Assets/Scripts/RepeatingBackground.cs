using UnityEngine;


	public class RepeatingBackground : MonoBehaviour
	{
		public float Speed;

		float endX;

		public void Start()
		{
			endX = GetComponent<SpriteRenderer>().size.x;
		}


		public void Update()
		{
			transform.localPosition += Speed * Vector3.right * Time.deltaTime;
			Repeat();
		}

		private void Repeat()
		{
			if (transform.localPosition.x >= endX / 4)
			{
				transform.localPosition += Vector3.left * endX / 2;
			}
			else if (transform.localPosition.x <= -endX / 4)
			{
				transform.localPosition += Vector3.right * endX / 2;
			}
		}
	}
