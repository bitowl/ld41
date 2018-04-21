using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashCounter : MonoBehaviour {
	public FloatVariable cash;
	public void OnEnemyDestroyed() {
		cash.value++;
	}
}
