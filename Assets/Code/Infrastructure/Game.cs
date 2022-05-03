using System;
using System.Collections;
using Code.Infrastructure.Services;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.States;
using Code.StaticData;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Game : MonoBehaviour
    {
        private const string GameConfigPath = "GameConfig";
        
        private static Game instance;

        [SerializeField]
        private SceneData _sceneData;

        private GameStateMachine _stateMachine;
        
        private void Awake()
        {
            instance = this;
            
            CreateStateMachine();
            
            AllServices.Container.RegisterSingle<GameStateMachine>(_stateMachine);
            
            _stateMachine.ChangeState<BootstrapState>();
        }

        private IEnumerator Start()
        {
            yield return null;
            _stateMachine.ChangeState<GameLoopState>();
        }

        private void CreateStateMachine()
        {
            StatesFactory factory = new StatesFactory(
                _sceneData,
                AllServices.Container, 
                transform, 
                Resources.Load<GameConfig>(GameConfigPath));
            
            _stateMachine = new GameStateMachine(factory);
        }
    }
}