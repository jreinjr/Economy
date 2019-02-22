using UnityEngine;

public class StateController : MonoBehaviour
{
    public State CurrentState { get; protected set; }

    protected Pop m_Pop;

    private void Start()
    {
        m_Pop = GetComponent<Pop>();
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }
}