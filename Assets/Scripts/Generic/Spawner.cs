﻿using System.Collections;
using UnityEngine;

/// <summary>
/// Spawn objects into the scene.
/// </summary>
public class Spawner : MonoBehaviour
{
	[Range (0.0f, 10.0f)]
	public float m_SpawnTime = 1f;

	[Range (1, 100)]
	public int m_SpawnCount = 1;

	[Range (1, 1000)]
	public int m_SpawnMaximum = 10;

	public Transform m_SpawnParent;

	public Vector2 m_Area;

	[Range (0.1f, 10.0f)]
	public float m_MinScale = 1.0f;
	[Range (0.1f, 10.0f)]
	public float m_MaxScale = 1.0f;

	[Range (0f, 100f)]
	public float m_GravityScale = 1.0f;

	[Range (0, 360)]
	public float m_RandomRotation = 0.0f;

	[Range (0, 31)]
	public int m_Layer;

	public GameObject[] m_SpawnItems;

	private int m_SpawnTotal;

	/// <summary>
	/// Infinitely spawn items until maximum allowed has been reached.
	/// </summary>
	/// <returns></returns>
	public IEnumerator Start ()
	{
		if (m_SpawnItems != null && m_SpawnItems.Length > 0)
		{
			while (true)
			{
				Spawn ();
				yield return new WaitForSeconds (m_SpawnTime);
			}
		}
	}

	/// <summary>
	/// Spawn the current items for this period.
	/// </summary>
	private void Spawn ()
	{
		for (int n = 0; n < m_SpawnCount; ++n)
		{
			if (m_SpawnTotal >= m_SpawnMaximum)
				return;

			var obj = m_SpawnItems[Random.Range (0, m_SpawnItems.Length)];
			if (obj)
			{
				var spawnRange = m_Area * 0.5f;
				var position = transform.TransformPoint (new Vector3 (Random.Range (-spawnRange.x, spawnRange.x), Random.Range (-spawnRange.y, spawnRange.y), transform.position.z));
				var rotation = Random.Range (0.0f, m_RandomRotation);
				var spawnObj = Instantiate (obj, position, Quaternion.Euler (0f, 0f, rotation), m_SpawnParent ? m_SpawnParent : transform);
				var randomScale = Random.Range (m_MinScale, m_MaxScale);
				spawnObj.transform.localScale = new Vector3 (randomScale, randomScale);
				spawnObj.layer = m_Layer;

				var body = spawnObj.GetComponent<Rigidbody2D> ();
				if (body)
					body.gravityScale = m_GravityScale;

				++m_SpawnTotal;
			}
		}
	}
}