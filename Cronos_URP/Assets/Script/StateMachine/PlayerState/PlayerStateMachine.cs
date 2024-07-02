
using UnityEngine;
//using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(InputReader))]         // 어트리뷰트를 상속받은 
[RequireComponent(typeof(Animator))]            // 사용지정 어트리뷰트 RequireComponenet
[RequireComponent(typeof(Rigidbody))] // 해당컴포넌트를 추가해준다

public class PlayerStateMachine : StateMachine
{
	static PlayerStateMachine instance;
	public static PlayerStateMachine GetInstance() { return instance; }

	public Vector3 Velocity;
    public Player Player { get; private set; }
    public InputReader InputReader { get; private set; }
    public Animator Animator { get; private set; }
	public Rigidbody Rigidbody { get; private set; }
    public Transform MainCamera { get; private set; }
    public Transform PlayerTransform { get; private set; }
    public HitStop HitStop { get; private set; }
	public AutoTargetting AutoTargetting;

	public void Awake()
	{
		instance = this;
	}
	public void OnEnable()
    {

        Player = GetComponent<Player>();
        InputReader = GetComponent<InputReader>();
		Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();

        MainCamera = Camera.main.transform;
        PlayerTransform = GetComponent<Transform>();
        HitStop = GetComponent<HitStop>();

		// 시작 상태를 정해준다.
		SwitchState(new PlayerMoveState(this));
	}
	private void SwitchToBuffState()
	{
		SwitchState(new PlayerBuffState(this));
	}
}
