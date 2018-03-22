using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

	public GameObject bulletPref;
	public Transform bulletSpwn;

	void Update()
	{
		if (!isLocalPlayer) 
		{
			return;
		}
		var hor = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var vert = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, hor, 0);
		transform.Translate(0, 0, vert);

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			CmdShoot();
		}
	}
		
	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer> ().material.color = Color.blue;
	}
	[Command]
	void CmdShoot()
	{
		//make bullet
		var bulletClone = (GameObject)Instantiate(bulletPref, bulletSpwn.position, bulletSpwn.rotation);

		//add velocity to shoot
		bulletClone.GetComponent<Rigidbody>().velocity = bulletClone.transform.forward * 6;

		NetworkServer.Spawn (bulletClone);
		Destroy (bulletClone, 2.0f);
	}

}