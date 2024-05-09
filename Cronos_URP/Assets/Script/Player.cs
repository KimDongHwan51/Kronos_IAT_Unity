using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


/// <summary>
/// Player가 갖는 정보를 한 눈에 볼 수 있는 플레이어 스크립트
/// 1. status
/// 2. Item
/// 3. 등등
/// </summary>
public class Player : MonoBehaviour
{

	[Header("State")]
	[SerializeField] private string CurrentState;

	[Header("Move Option")]
	[SerializeField] private float Speed = 5f;
	[SerializeField] private float JumpForce = 10f;
	[SerializeField] private float LookRotationDampFactor = 10f;

	//[Header("Play Option")]
	//[SerializeField] private float HitRange = 5f;


	PlayerStateMachine PlayerFSM;

	public float moveSpeed { get { return Speed; } }
	public float jumpForce { get { return JumpForce; } }
	public float lookRotationDampFactor { get { return LookRotationDampFactor; } }

	// chronos in game Option
	private float CP { get; set; }
	private float TP { get; set; }

	// 플레이어 데이터를 저장하고 respawn시 반영하는 데이터
	PlayerData playerData = new PlayerData();
	Transform playerTransform;

	private void Start()
	{
		// 감속/가속 변경함수를 임시로 사용해보자
		// 반드시 지워져야할 부분이지만 임시로 넣는다
		PlayerFSM = GetComponent<PlayerStateMachine>();
		playerTransform = GetComponent<Transform>();

	}

	private void Update()
	{

		CurrentState = PlayerFSM.GetState().GetType().Name;

		if (Input.GetKeyDown(KeyCode.I))
		{
			Debug.Log($"저장된 포지션 {playerData.RespawnPos.x}, {playerData.RespawnPos.y}, {playerData.RespawnPos.z}");
		}
	}



	public void SavePlayerData()
	{
		playerData.TP = TP;
		playerData.TP = CP;
		playerData.RespawnPos = playerTransform.position;
		// 필요한 데이터를 여기 계속 더하자
	}

	public void PlayerRespawn()
	{
		TP = playerData.TP;
		CP = playerData.CP;
		playerTransform.position = playerData.RespawnPos;
	}


	// 플레이어를 죽이자
	public void PlayerDeath()
	{
		TP = 0f;
	}
}
