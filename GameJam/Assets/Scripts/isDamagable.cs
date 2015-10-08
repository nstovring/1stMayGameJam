using UnityEngine;
using System.Collections;

public interface IDamagable {
	void RecieveDamage (int damage);
}

public interface IKillable {
	void Die ();
}


