using UnityEngine;


	public class RepeatingBackground : MonoBehaviour
	{
		float Speed;

		float endX;

		[SerializeField] Rigidbody2D rb;
		[SerializeField] float parallaxVelocity;

		public void Start()
		{
			endX = GetComponent<SpriteRenderer>().size.x;
		}


		public void Update()
		{
			//endX = GetComponent<SpriteRenderer>().size.x;

			Speed = rb.velocity.x / parallaxVelocity;

			transform.localPosition -= Speed * Vector3.right * Time.deltaTime;
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
